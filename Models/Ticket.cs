using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace help_desk.Models;

public class Ticket
{
    public int Id { get; set; }
    [StringLength(60, MinimumLength = 3), Required]
    public string? Subject { get; set; }
    public Category? Category { get; set; }
    [Display(Name = "Creation Date"), DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Required, StringLength(60, MinimumLength = 10)]
    public string? Description { get; set; }
    [Required]
    public Priority? Priority { get; set; }

}   
public enum Category{
    Incident,
    Change,
    Request
}
public enum Priority{
    High,
    Normal,
    Low
}
