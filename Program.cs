using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using HUKUK_PROJE.Context;
using HUKUK_PROJE.Entities;

var builder = WebApplication.CreateBuilder(args);

// MVC + Authorization filter
builder.Services.AddControllersWithViews(options =>
{
	var policy = new AuthorizationPolicyBuilder()
		.RequireAuthenticatedUser()
		.Build();
	options.Filters.Add(new AuthorizeFilter(policy));
});

// DbContext ayarı
builder.Services.AddDbContext<HukukContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Identity ayarı
builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options =>
{
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireUppercase = true;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<HukukContext>()
.AddDefaultTokenProviders();

// Cookie ayarı (Login yönlendirmesi burada)
builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Login/Index"; // Doğru login path burası!
	options.AccessDeniedPath = "/Login/Index";
	options.ReturnUrlParameter = "ReturnUrl";
	options.Cookie.Name = "AspNetCore_MVC_Admin";
	options.Cookie.HttpOnly = true;
	options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
	options.Cookie.SameSite = SameSiteMode.Strict;
	options.ExpireTimeSpan = TimeSpan.FromHours(15); // Oturum süresi
});

var app = builder.Build();

// Hata sayfası
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
// Otomatik migration işlemi
using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<HukukContext>();

	// appsettings.json'dan SiteNo okuma
	var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
	dbContext.Database.Migrate();

}

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

	var userManager = services.GetRequiredService<UserManager<AppUser>>();

	var config = services.GetRequiredService<IConfiguration>();

	// Admin kullanıcısı var mı kontrol et
	var adminUser = await userManager.FindByNameAsync("Admin");
	if (adminUser == null)
	{
		var user = new AppUser
		{
			UserName = "Admin",
			Email = "admin@example.com",
			Name = "Yönetici",
			EmailConfirmed = true,
			ConfirmCode = 0
		};

		var result = await userManager.CreateAsync(user, "123456aA*");
	}
}

// Static dosyalar ve middleware
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); // Giriş kontrolü
app.UseAuthorization();  // Yetki kontrolü

// Default route
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
