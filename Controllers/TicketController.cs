using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using help_desk.Models;

namespace help_desk.Controllers;

public class TicketController : Controller
{
    private readonly ILogger<TestController> _logger;

    public TicketController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    public IActionResult Ticket()
    {

        var ticket = new Ticket(1, "ticketprueba", DateTime.Now, "hola");
        ViewData["Ticket"] = ticket;  
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
