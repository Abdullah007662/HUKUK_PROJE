using HUKUK_PROJE.Context;
using Microsoft.EntityFrameworkCore;

namespace HUKUK_PROJE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // **DbContext Yapýlandýrmasý**
            builder.Services.AddDbContext<HukukContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // **Veritabaný Migrations Ýþlemini Otomatik Çalýþtýrma**
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<HukukContext>();
                context.Database.Migrate(); // Eðer migration yoksa, oluþturur
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Default}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
