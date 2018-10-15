namespace FinalBugTracker.Migrations
{
    using FinalBugTracker.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalBugTracker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FinalBugTracker.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(p => p.Name == "Admin"))
            {
                var role = new IdentityRole("Admin");

                roleManager.Create(role);
            }
            if (!context.Roles.Any(p => p.Name == "Project Manager"))
            {
                roleManager.Create(new IdentityRole("Project Manager"));
            }

            if (!context.Roles.Any(p => p.Name == "Developer"))
            {
                roleManager.Create(new IdentityRole("Developer"));
            }

            if (!context.Roles.Any(p => p.Name == "Submitter"))
            {
                roleManager.Create(new IdentityRole("Submitter"));
            }

            if (!context.Users.Any(u => u.Email == "myblogapp0@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "myblogapp0@gmail.com",
                    Email = "myblogapp0@gmail.com",
                    Name = "Foyaz",
                    FirstName = "Foyaz Ahmed",
                    LastName = "Ahmed",
                }, "myblogapp0@");
            }
            var adminId = userManager.FindByEmail("myblogapp0@gmail.com").Id;
            userManager.AddToRole(adminId, "Admin");

            if (!context.Users.Any(u => u.Email == "ProjectManager@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "ProjectManager@gmail.com",
                    Email = "ProjectManager@gmail.com",
                    Name = "ProjectManager",
                    FirstName = "P",
                    LastName = "M",
                }, "ProjectManager@");
            }
            var projectManagerId = userManager.FindByEmail("ProjectManager@gmail.com").Id;
            userManager.AddToRole(projectManagerId, "Project Manager");

            if (!context.Users.Any(u => u.Email == "Developer@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "Developer@gmail.com",
                    Email = "Developer@gmail.com",
                    Name = "Developer",
                    FirstName = "Developer",
                    LastName = "Developer2",
                }, "Developer@");
            }
            var DeveloperId = userManager.FindByEmail("Developer@gmail.com").Id;
            userManager.AddToRole(DeveloperId, "Developer");

            if (!context.Users.Any(u => u.Email == "Submitter@gamil.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "Submitter@gamil.com",
                    Email = "Submitter@gamil.com",
                    Name = "Submitter",
                    FirstName = "Submitter",
                    LastName = "Submitter2",
                }, "Submitter@");
            }
            var SubmitterId = userManager.FindByEmail("Submitter@gmail.com").Id;
            userManager.AddToRole(SubmitterId, "Submitter");


        }
    }
}
