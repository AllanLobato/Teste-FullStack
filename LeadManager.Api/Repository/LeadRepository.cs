using LeadManager.Api.Data;
using LeadManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Api.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly AppDbContext _context;

        public LeadRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lead> GetLeads(string? status)
        {
            var query = _context.Leads.AsQueryable();
            if (!string.IsNullOrEmpty(status))
                query = query.Where(l => l.Status == status);
            return query.ToList();
        }

        public Lead? GetLeadById(int id)
        {
            return _context.Leads.Find(id);
        }

        public void UpdateLead(Lead lead)
        {
            _context.Leads.Update(lead);
            _context.SaveChanges();
        }
    }
}