using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using help_desk.Models;

    public class HelpDeskContext : DbContext
    {
        public HelpDeskContext (DbContextOptions<HelpDeskContext> options)
            : base(options)
        {
        }

        public DbSet<help_desk.Models.Ticket> Ticket { get; set; } = default!;
    }
