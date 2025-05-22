import { useEffect, useState } from "react";
import { getLeadsByStatus } from "../api/leadService";
import type { Lead } from "../types/Lead";
import LeadCard from "../components/LeadCard";

export default function Accepted() {
  const [leads, setLeads] = useState<Lead[]>([]);

  useEffect(() => {
    getLeadsByStatus("accepted").then(setLeads);
  }, []);

  return (
    <div className="bg-gray-100 min-h-screen pl-4 pr-4">
      {leads.map((lead) => (
        <LeadCard key={lead.id} lead={lead} />
      ))}
    </div>
  );
}
