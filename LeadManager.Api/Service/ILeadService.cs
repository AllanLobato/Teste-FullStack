using LeadManager.Api.Models;

namespace LeadManager.Api.Services
{
    public interface ILeadService
    {
        IEnumerable<Lead> GetLeads(string? status);
        bool AcceptLead(int id);
        bool DeclineLead(int id);
    }
}