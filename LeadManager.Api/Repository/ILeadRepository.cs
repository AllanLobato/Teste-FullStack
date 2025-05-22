using LeadManager.Api.Models;

namespace LeadManager.Api.Repositories
{
    public interface ILeadRepository
    {
        IEnumerable<Lead> GetLeads(string? status);
        Lead? GetLeadById(int id);
        void UpdateLead(Lead lead);
    }
}