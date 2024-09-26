using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.Data
{
    [Area("User")]
    public class ApplicationDbContext : IdentityDbContext<AppUserDTO>
    {
        public DbSet<UserAccountDTO> AspNetUserAccounts { get; set; }
        public DbSet<ProfileGroupDTO> AspNetProfileGroup { get; set; }
        public DbSet<ProfileOrbitaDTO> AspNetProfileOrbita { get; set; }
        
        public DbSet<FacebookAccountDTO> AspNetFacebookAccount { get; set; }

        public DbSet<GoogleAccountDTO> AspNetGoogleAccount { get; set; }
        public DbSet<HotmailOutlookDTO> AspNetHotmailOutlook { get; set; }

        public DbSet<SocialSelectDTO> AspNetSocial { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // Configure automatic primary key generation if needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure automatic primary key generation if needed
            modelBuilder.Entity<UserAccountDTO>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ProfileGroupDTO>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ProfileOrbitaDTO>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<FacebookAccountDTO>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<GoogleAccountDTO>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<SocialSelectDTO>().Property(p => p.Id).ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);
        }
    }
}
