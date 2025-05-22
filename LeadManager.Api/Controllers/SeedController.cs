using LeadManager.Api.Data;
using LeadManager.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeadManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeedController : ControllerBase
{
    private readonly AppDbContext _context;

    public SeedController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Seed()
    {
        var random = new Random();

        string[] firstNames = { "Ana", "Bruno", "Carlos", "Daniela", "Eduardo", "Fernanda", "Gustavo", "Helena" };
        string[] suburbs = { "Moema", "Jardins", "Centro", "Pinheiros", "Vila Mariana" };
        string[] categories = { "Pintura", "Eletricista", "Pedreiro", "Encanador" };
        string[] descriptions = {
            "Instalar luminárias no quarto e sala.",
            "Pintura externa da casa.",
            "Reparo em encanamento do banheiro.",
            "Troca de disjuntor no quadro.",
            "Construção de parede drywall."
        };

        var leads = new List<Lead>();

        for (int i = 0; i < 5; i++)
        {
            var name = firstNames[random.Next(firstNames.Length)];
            var fullName = $"{name} Teste";
            var suburb = suburbs[random.Next(suburbs.Length)];
            var category = categories[random.Next(categories.Length)];
            var description = descriptions[random.Next(descriptions.Length)];
            var price = random.Next(100, 1000);
            var phone = $"0{random.Next(100000000, 999999999)}";
            var email = $"{name.ToLower()}{random.Next(1000)}@teste.com";

            leads.Add(new Lead
            {
                FirstName = name,
                FullName = fullName,
                Suburb = suburb,
                Category = category,
                Description = description,
                Price = price,
                Phone = phone,
                Email = email,
                CreatedAt = DateTime.Now.AddDays(-random.Next(1, 30)).AddHours(-random.Next(0, 24)).AddMinutes(-random.Next(0, 60)),
                Status = "invited"
            });
        }

        _context.Leads.AddRange(leads);
        _context.SaveChanges();

        return Ok("Leads aleatórios criados com sucesso!");
    }

    [HttpDelete]
    public IActionResult ClearLeads()
    {
        _context.Leads.RemoveRange(_context.Leads);
        _context.SaveChanges();
        return Ok("Leads removidos com sucesso!");
    }
}
