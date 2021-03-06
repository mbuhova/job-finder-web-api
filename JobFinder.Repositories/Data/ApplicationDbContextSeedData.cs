﻿namespace JobFinder.Repositories.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using JobFinder.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationDbContextSeedData
    {

       //public static void SeedDatabase(/*this IApplicationBuilder app,*/ IServiceProvider serviceProvider)
       //{
       //    var db = serviceProvider.GetService<ApplicationDbContext>();
       //    db.Database.Migrate();
       //
       //    //SeedData(db);
       //
       //    db.SaveChanges();
       //}

        public static void SeedData(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();
            AddBusinessSectors(context);
            AddTowns(context);
            //AddRoles(context);
            AddUsersAndRoles(context, userManager, roleManager);
        }

        private static void AddRoles(ApplicationDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new Microsoft.AspNetCore.Identity.IdentityRole() { Name = "Admin" });
                context.Roles.Add(new Microsoft.AspNetCore.Identity.IdentityRole() { Name = "Person" });
                context.Roles.Add(new Microsoft.AspNetCore.Identity.IdentityRole() { Name = "Company" });

                context.SaveChanges();
            }
        }

        private static void AddUsersAndRoles(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!context.Roles.Any())
            {
                //context.Roles.Add(new Microsoft.AspNetCore.Identity.IdentityRole() { Name = "Admin" });
                //context.Roles.Add(new Microsoft.AspNetCore.Identity.IdentityRole() { Name = "Person" });
                //context.Roles.Add(new Microsoft.AspNetCore.Identity.IdentityRole() { Name = "Company" });

                roleManager.CreateAsync(new IdentityRole() { Name = "Admin" }).Wait();
                roleManager.CreateAsync(new IdentityRole() { Name = "Person" }).Wait();
                roleManager.CreateAsync(new IdentityRole() { Name = "Company" }).Wait();

                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var admin = new ApplicationUser() { Email = "admin@admin.bg", UserName = "admin@admin.bg" };
                var company = new ApplicationUser() { Email = "company@company.bg", UserName = "company@company.bg", Bulstat = "1234567891234", IsApproved = true };
                var person = new ApplicationUser() { Email = "person@person.bg", UserName = "person@person.bg" };

                userManager.CreateAsync(admin, "Admin@123").Wait();
                userManager.CreateAsync(company, "Company@123").Wait();
                userManager.CreateAsync(person, "Person@123").Wait();

                userManager.AddToRoleAsync(admin, "Admin").Wait();
                userManager.AddToRoleAsync(company, "Company").Wait();
                userManager.AddToRoleAsync(person, "Person").Wait();
                
                context.SaveChanges();
            }
        }

        private static void AddBusinessSectors(ApplicationDbContext context)
        {
            if (!context.BusinessSectors.Any())
            {
                context.BusinessSectors.Add(new BusinessSector() { Name = "Accounting, Audit, Finance" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Administrative and office" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Advertising, PR" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Architecture, Construction" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Automotive, Auto Service, Gas Stations" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Aviation, Airport & Airline" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Banking, Lending" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Beauty, SPA & Salon" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Design, Creative, Video & Animation" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Drivers, Couriers" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Education, Courses, Translators" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Engineers" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Healthcare and pharmacy" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Human Resources" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Insurance" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "IT - Administration and sales" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "IT - Software development/maintenance" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Management, Business development" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Manufacturing - Food and Beverage" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Marketing" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Real-estate" });
                context.BusinessSectors.Add(new BusinessSector() { Name = "Security" });

                context.SaveChanges();
            }
        }

        private static void AddTowns(ApplicationDbContext context)
        {
            if (!context.Towns.Any())
            {
                context.Towns.Add(new Town() { Name = "Blagoevgrad" });
                context.Towns.Add(new Town() { Name = "Burgas" });
                context.Towns.Add(new Town() { Name = "Dobrich" });
                context.Towns.Add(new Town() { Name = "Gabrovo" });
                context.Towns.Add(new Town() { Name = "Haskovo" });
                context.Towns.Add(new Town() { Name = "Kardzhali" });
                context.Towns.Add(new Town() { Name = "Kystendil" });
                context.Towns.Add(new Town() { Name = "Lovech" });
                context.Towns.Add(new Town() { Name = "Montana" });
                context.Towns.Add(new Town() { Name = "Pazardzhik" });
                context.Towns.Add(new Town() { Name = "Pernik" });
                context.Towns.Add(new Town() { Name = "Pleven" });
                context.Towns.Add(new Town() { Name = "Razgrad" });
                context.Towns.Add(new Town() { Name = "Plovdiv" });
                context.Towns.Add(new Town() { Name = "Ruse" });
                context.Towns.Add(new Town() { Name = "Shumen" });
                context.Towns.Add(new Town() { Name = "Silistra" });
                context.Towns.Add(new Town() { Name = "Smolyan" });
                context.Towns.Add(new Town() { Name = "Sofia" });
                context.Towns.Add(new Town() { Name = "Varna" });
                context.Towns.Add(new Town() { Name = "Veliko Tarnovo" });
                context.Towns.Add(new Town() { Name = "Sliven" });

                context.SaveChanges();
            }


            //context.Deliveries.AddIfNotExists(del1, x => x.DeliveryId == del1.DeliveryId && Math.Floor(x.TruckNumber) == Math.Floor(del1.TruckNumber));

        }

        private static void AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate)
            where T : class
        {
            var dbEntity = dbSet.FirstOrDefault(predicate);
            if (dbEntity == null)
            {
                dbSet.Add(entity);
            }
        }
    }
}
