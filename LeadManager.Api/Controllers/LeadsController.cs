using LeadManager.Api.Data;
using LeadManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeadsController : ControllerBase
{
    private readonly AppDbContext _context;

    public LeadsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Lead>> GetLeads([FromQuery] string? status)
    {
        var query = _context.Leads.AsQueryable();

        if (!string.IsNullOrEmpty(status))
            query = query.Where(l => l.Status == status);

        return Ok(query.ToList());
    }

    [HttpPost("{id}/accept")]
    public  IActionResult AcceptLead(int id)
    {
        var lead =  _context.Leads.Find(id);
        if (lead == null) return NotFound();

        lead.Status = "accepted";
        if (lead.Price > 500)
            lead.Price *= 0.9m;

         _context.SaveChanges();

        // Simulação de envio de e-mail
        System.IO.File.WriteAllText($"email_{lead.Id}.txt", $"Lead {lead.FullName} aceito.");

        return NoContent();
    }

    [HttpPost("{id}/decline")]
    public IActionResult DeclineLead(int id)
    {
        var lead =  _context.Leads.Find(id);
        if (lead == null) return NotFound();

        lead.Status = "declined";
         _context.SaveChanges();

        return NoContent();
    }
}
