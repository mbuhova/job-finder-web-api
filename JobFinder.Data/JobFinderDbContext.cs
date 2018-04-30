namespace JobFinder.Data
{
    using System;
    using JobFinder.Models;
    using Microsoft.EntityFrameworkCore;

    public class JobFinderDbContext : DbContext
    {
        public JobFinderDbContext(DbContextOptions<JobFinderDbContext> options)
            : base(options)  
        {
            
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<BusinessSector> BusinessSectors { get; set; }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<Application> Applications { get; set; }

        public virtual DbSet<JobOffer> JobOffers { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<BusinessSector>()
            //    .HasKey(x => x.Id);

            //builder.Entity<Company>()
            //    .HasKey(x => x.CompanyId);

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

            //builder.Entity<TruckPosition>().HasKey(e => new { e.DeliveryId, e.TruckNumber, e.OrderId, e.PlaceId });

            //builder.Entity<ConstructionPlace>().HasKey(x => new { x.ConstructionPlaceId, x.PlaceId });

            //builder.Entity<Delivery>().HasKey(x => new { x.DeliveryId, x.TruckNumber });

            builder.Entity<Company>()
            .HasIndex(u => u.Bulstat)
            .IsUnique();

            builder.Entity<Company>()
           .HasIndex(u => u.CompanyName)
           .IsUnique();

            builder.Entity<User>()
           .HasIndex(u => u.Email)
           .IsUnique();

            builder.Entity<User>()
           .HasIndex(u => u.Username)
           .IsUnique();

            builder.Entity<Town>()
           .HasIndex(u => u.Name)
           .IsUnique();

            builder.Entity<BusinessSector>()
           .HasIndex(u => u.Name)
           .IsUnique();
        }
    }
}
