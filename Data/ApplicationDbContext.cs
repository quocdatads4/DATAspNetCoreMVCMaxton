using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DATAspNetCoreMVCMaxton.Models;

namespace DATAspNetCoreMVCMaxton.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUserModel>
	{
		public DbSet<ProfileOrbitaModel> AspNetProfileOrbita { get; set; }
		public DbSet<ProfileGroupModel> AspNetProfileGroup { get; set; }
		public DbSet<UserAccountModel> AspNetUserAccounts { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		// Configure automatic primary key generation if needed
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Configure automatic primary key generation if needed
			modelBuilder.Entity<UserAccountModel>()
						.Property(p => p.Id)
						.ValueGeneratedOnAdd();
			modelBuilder.Entity<ProfileGroupModel>().Property(p => p.Id).ValueGeneratedOnAdd();
			modelBuilder.Entity<ProfileOrbitaModel>().Property(p => p.ID).ValueGeneratedOnAdd();
			base.OnModelCreating(modelBuilder);
		}
	}
}
