﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DATAspNetCoreMVCMaxton.Areas.User.Models;

namespace DATAspNetCoreMVCMaxton.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<AppUserDTO>
	{
		public DbSet<ProfileOrbitaDTO> AspNetProfileOrbita { get; set; }
		public DbSet<ProfileGroupDTO> AspNetProfileGroup { get; set; }
		public DbSet<UserAccountDTO> AspNetUserAccounts { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		// Configure automatic primary key generation if needed
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Configure automatic primary key generation if needed
			modelBuilder.Entity<UserAccountDTO>()
						.Property(p => p.Id)
						.ValueGeneratedOnAdd();
			modelBuilder.Entity<ProfileGroupDTO>().Property(p => p.Id).ValueGeneratedOnAdd();
			modelBuilder.Entity<ProfileOrbitaDTO>().Property(p => p.Id).ValueGeneratedOnAdd();
			base.OnModelCreating(modelBuilder);
		}
	}
}
