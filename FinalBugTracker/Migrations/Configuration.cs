namespace FinalBugTracker.Migrations
{
    using FinalBugTracker.Models;
    using FinalBugTracker.Models.TicketClasses;
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

            ApplicationUser adminUser;

            if (!context.Users.Any(p => p.UserName == "admin@bugtracker.com"))
            {
                adminUser = new ApplicationUser();
                adminUser.Email = "admin@bugtracker.com";
                adminUser.UserName = "admin@bugtracker.com";

                userManager.Create(adminUser, "Password-1");
            }
            else
            {
                adminUser = context.Users.First(p => p.UserName == "admin@bugtracker.com");
            }

            if (!userManager.IsInRole(adminUser.Id, "Admin"))
            {
                userManager.AddToRole(adminUser.Id, "Admin");
            }


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

            if (!context.Users.Any(u => u.Email == "Submitter@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "Submitter@gmail.com",
                    Email = "Submitter@gmail.com",
                    Name = "Submitter",
                    FirstName = "Submitter",
                    LastName = "Submitter2",
                }, "Submitter@");
            }
            var SubmitterId = userManager.FindByEmail("Submitter@gmail.com").Id;
            userManager.AddToRole(SubmitterId, "Submitter");

            context.TicketPriorities.AddOrUpdate(p => p.Name,
            new TicketPriority { Name = "High" },
            new TicketPriority { Name = "Medium" },
            new TicketPriority { Name = "Low" },
            new TicketPriority { Name = "Optional" }
        );
            context.TicketTypes.AddOrUpdate(t => t.Name,
               new TicketType { Name = "Bug" },
               new TicketType { Name = "Documentation" },
               new TicketType { Name = "New Request" }
           );
            context.TicketStatus.AddOrUpdate(s => s.Name,
               new TicketStatus { Name = "Active" },
               new TicketStatus { Name = "In Progress" },
               new TicketStatus { Name = "Optional" }
           );
        }
    }
}
