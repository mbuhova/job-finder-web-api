using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Repositories.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BusinessSector> BusinessSectors { get; set; }

        public virtual DbSet<Application> Applications { get; set; }

        public virtual DbSet<JobOffer> JobOffers { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<SectorCompany>()
                .HasKey(x => new { x.BusinessSectorId, x.CompanyId });
            builder.Entity<SectorCompany>()
                .HasOne(x => x.BusinessSector)
                .WithMany(m => m.Companies)
                .HasForeignKey(x => x.BusinessSectorId);
            builder.Entity<SectorCompany>()
                .HasOne(x => x.Company)
                .WithMany(e => e.BusinessSectors)
                .HasForeignKey(x => x.CompanyId);

            builder.Entity<PersonOffer>()
               .HasKey(x => new { x.PersonId, x.JobOfferId });
            builder.Entity<PersonOffer>()
                .HasOne(x => x.Person)
                .WithMany(m => m.FollowedOffers)
                .HasForeignKey(x => x.PersonId);
            builder.Entity<PersonOffer>()
                .HasOne(x => x.JobOffer)
                .WithMany(e => e.PeopleFollowing)
                .HasForeignKey(x => x.JobOfferId);

            builder.Entity<ApplicationUser>()
            .HasIndex(u => u.Bulstat)
            .IsUnique();

            builder.Entity<ApplicationUser>()
           .HasIndex(u => u.CompanyName)
           .IsUnique();

            // builder.Entity<ApplicationUser>()
            //.HasIndex(u => u.Email)
            //.IsUnique();

            builder.Entity<Town>()
           .HasIndex(u => u.Name)
           .IsUnique();

            builder.Entity<BusinessSector>()
           .HasIndex(u => u.Name)
           .IsUnique();
        }
    }
}
