using LeadManager.Api.Models;
using LeadManager.Api.Repositories;

namespace LeadManager.Api.Services
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _repository;

        public LeadService(ILeadRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Lead> GetLeads(string? status)
        {
            return _repository.GetLeads(status);
        }

        public  bool AcceptLead(int id)
        {
            var lead =  _repository.GetLeadById(id);
            if (lead == null) return false;

            lead.Status = "accepted";
            if (lead.Price > 500)
                lead.Price *= 0.9m;

             _repository.UpdateLead(lead);

            // Simulação de envio de e-mail
            System.IO.File.WriteAllText($"email_{lead.Id}.txt", $"Lead {lead.FullName} aceito.");

            return true;
        }

        public bool DeclineLead(int id)
        {
            var lead =  _repository.GetLeadById(id);
            if (lead == null) return false;

            lead.Status = "declined";
             _repository.UpdateLead(lead);

            return true;
        }
    }
}