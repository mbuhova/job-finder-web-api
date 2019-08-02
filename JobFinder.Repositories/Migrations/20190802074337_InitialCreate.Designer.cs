﻿// <auto-generated />
using JobFinder.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace JobFinder.Repositories.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190802074337_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobFinder.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType");

                    b.Property<DateTime>("DateUploaded");

                    b.Property<byte[]>("FileData");

                    b.Property<string>("FileName")
                        .IsRequired();

                    b.Property<long>("FileSize");

                    b.Property<bool?>("IsApproved");

                    b.Property<int>("JobOfferId");

                    b.Property<string>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("JobOfferId");

                    b.HasIndex("PersonId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("JobFinder.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutUs");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("Bulstat")
                        .HasMaxLength(13);

                    b.Property<string>("CompanyName")
                        .HasMaxLength(60);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsApproved");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int?>("TownId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("WebSite");

                    b.HasKey("Id");

                    b.HasIndex("Bulstat")
                        .IsUnique()
                        .HasFilter("[Bulstat] IS NOT NULL");

                    b.HasIndex("CompanyName")
                        .IsUnique()
                        .HasFilter("[CompanyName] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("TownId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("JobFinder.Models.BusinessSector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("BusinessSectors");
                });

            modelBuilder.Entity("JobFinder.Models.JobOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationsCount");

                    b.Property<int>("BusinessSectorId");

                    b.Property<string>("CompanyId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<bool?>("IsFullTime");

                    b.Property<bool?>("IsPermanent");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("TownId");

                    b.Property<int>("Views");

                    b.HasKey("Id");

                    b.HasIndex("BusinessSectorId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("TownId");

                    b.ToTable("JobOffers");
                });

            modelBuilder.Entity("JobFinder.Models.PersonOffer", b =>
                {
                    b.Property<string>("PersonId");

                    b.Property<int>("JobOfferId");

                    b.Property<int>("Id");

                    b.HasKey("PersonId", "JobOfferId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("JobOfferId");

                    b.ToTable("PersonOffer");
                });

            modelBuilder.Entity("JobFinder.Models.SectorCompany", b =>
                {
                    b.Property<int>("BusinessSectorId");

                    b.Property<string>("CompanyId");

                    b.Property<int>("Id");

                    b.HasKey("BusinessSectorId", "CompanyId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("SectorCompany");
                });

            modelBuilder.Entity("JobFinder.Models.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("JobFinder.Models.Application", b =>
                {
                    b.HasOne("JobFinder.Models.JobOffer", "JobOffer")
                        .WithMany("Applications")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobFinder.Models.ApplicationUser", "Person")
                        .WithMany("Applications")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("JobFinder.Models.ApplicationUser", b =>
                {
                    b.HasOne("JobFinder.Models.Town", "Town")
                        .WithMany()
                        .HasForeignKey("TownId");
                });

            modelBuilder.Entity("JobFinder.Models.JobOffer", b =>
                {
                    b.HasOne("JobFinder.Models.BusinessSector", "BusinessSector")
                        .WithMany()
                        .HasForeignKey("BusinessSectorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobFinder.Models.ApplicationUser", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("JobFinder.Models.Town", "Town")
                        .WithMany("JobOffers")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobFinder.Models.PersonOffer", b =>
                {
                    b.HasOne("JobFinder.Models.JobOffer", "JobOffer")
                        .WithMany("PeopleFollowing")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobFinder.Models.ApplicationUser", "Person")
                        .WithMany("FollowedOffers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobFinder.Models.SectorCompany", b =>
                {
                    b.HasOne("JobFinder.Models.BusinessSector", "BusinessSector")
                        .WithMany("Companies")
                        .HasForeignKey("BusinessSectorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobFinder.Models.ApplicationUser", "Company")
                        .WithMany("BusinessSectors")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JobFinder.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JobFinder.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobFinder.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JobFinder.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}