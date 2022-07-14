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
   

}   

