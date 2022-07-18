using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace help_desk.Models;

public class Ticket
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Category { get; set; }
    [Display(Name = "Creation Date")]
    [DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }
    public string? Description { get; set; }
   
}   

