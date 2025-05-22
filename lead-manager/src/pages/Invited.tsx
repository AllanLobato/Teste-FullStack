import { useEffect, useState } from 'react';
import { getLeadsByStatus, acceptLead, declineLead } from '../api/leadService';
import type { Lead } from '../types/Lead';
import LeadCard from '../components/LeadCard';

export default function Invited() {
  const [leads, setLeads] = useState<Lead[]>([]);

  useEffect(() => {
    getLeadsByStatus('invited').then((data) => {
    console.log('Leads recebidos:', data); // <--- AQUI
    setLeads(data);
  });
  }, []);

  const handleAccept = async (id: number) => {
    await acceptLead(id);
    const updated = await getLeadsByStatus('invited');
    setLeads(updated);
  };

  const handleDecline = async (id: number) => {
    await declineLead(id);
    const updated = await getLeadsByStatus('invited');
    setLeads(updated);
  };

  return (
    <div className="bg-gray-100 min-h-screen pl-4 pr-4">
      {leads.map((lead) => (
        <LeadCard key={lead.id} lead={lead} onAccept={handleAccept} onDecline={handleDecline} />
      ))}
    </div>
  );
}
