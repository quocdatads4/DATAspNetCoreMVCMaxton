using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DATAspNetCoreMVCMaxton.Models;

namespace DATAspNetCoreMVCMaxton.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
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

			base.OnModelCreating(modelBuilder);
		}
	}
}
