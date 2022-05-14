using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace help_desk.Models;

public class Ticket
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }

    public string? Description { get; set; }

    //Test of a ticket
    public Ticket(){
       this.Id = 1;
       this.Name = "Ticket 1";
       this.CreationDate = DateTime.Now;
       this.Description=("brief description");
   }
    //Constructor
    public Ticket(int id, string name, DateTime creationDate, string description)
    {
        Id = id;
        Name = name;
        CreationDate = creationDate;
        Description = description;
    }

    //Related to DataBase conneciton and to be able to write/read things
    public class TicketDBContext : DbContext
    {
        public DbSet<Ticket> Ticket { get; set; }
    }
    
    

}   

