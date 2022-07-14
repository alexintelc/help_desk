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
                        Id = 1,
                        Name = "ticket1",
                        CreationDate = DateTime.Parse("1989-2-12"),
                        Description = "Description ticket1",

                    },                   
                    new Ticket
                    {
                        Id = 2,
                        Name = "ticket1",
                        CreationDate = DateTime.Parse("1989-2-12"),
                        Description = "2222222",

                    },       
                    new Ticket
                    {
                        Id = 3,
                        Name = "ticket2",
                        CreationDate = DateTime.Parse("1989-2-12"),
                        Description = "333333333333",

                    }
                );
                context.SaveChanges();
            }
        }
    }
}