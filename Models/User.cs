using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace help_desk.Models;

public class User
{
    public int Id { get; set; }
    [StringLength(30, MinimumLength = 5), Required]
    public string? UserName { get; set; }
    [StringLength(30, MinimumLength = 5), Required]
    public string?  UserPassword { get; set; }



}   