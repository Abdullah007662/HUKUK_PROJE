using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HUKUK_PROJE.Entities;

namespace HUKUK_PROJE.Context
{
    public class HukukContext : IdentityDbContext<AppUser, AppRole, int>

    {
        private readonly IConfiguration _configuration;

        public HukukContext(DbContextOptions<HukukContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<LawTypes> LawTypes { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
