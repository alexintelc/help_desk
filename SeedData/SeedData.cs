using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace help_desk.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HelpDeskContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HelpDeskContext>>()))
            {
                // Look for any movies.
                if (context.Ticket.Any())
                {
                    return;   // DB has been seeded
                }

                context.Ticket.AddRange(
                    new Ticket
                    {
                        Id = 001,
                        Name = "Ticket 1",
                        Category = "Incident",
                        CreationDate = DateTime.Parse("1989-2-12"),
                        Description = "Description ticket 1",

                    },                   
                    new Ticket
                    {
                        Id = 002,
                        Name = "Ticket 2",
                        Category = "Change",
                        CreationDate = DateTime.Parse("1989-2-12"),
                        Description = "Description lorem whatever xd ",
                    },       
                    new Ticket
                    {
                        Id = 003,
                        Name = "Ticket 3",
                        Category = "Incident",
                        CreationDate = DateTime.Parse("1989-2-12"),
                        Description = "It seems as I am having issues with adding variables",

                    },
                    new Ticket
                    {
                        Id = 004,
                        Name = "Ticket 4",
                        Category = "Incident",
                        CreationDate = DateTime.Parse("1989-2-12"),
                        Description = "I am trying to add new variables to an existing ticket model",

                    }
                );
                context.SaveChanges();
            }
        }
    }
}