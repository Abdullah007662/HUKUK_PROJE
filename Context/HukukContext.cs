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
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<PracticeArea>()
	.HasOne(p => p.LawTypes)
	.WithMany()
	.HasForeignKey(p => p.LawTypesID)
	.OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<Area>()
	.HasOne(a => a.LawTypes)
	.WithMany()
	.HasForeignKey(a => a.LawTypesID)
	.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<PracticeArea>()
				.HasOne(p => p.Area)
				.WithMany()
				.HasForeignKey(p => p.AreaID)
				.OnDelete(DeleteBehavior.Restrict); // veya DeleteBehavior.NoAction


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
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<PracticeArea> PracticeAreas { get; set; }
		public DbSet<Area> Areas { get; set; }
		public DbSet<Deneme> Denemes { get; set; }
	}
}
