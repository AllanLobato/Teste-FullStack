import type { Lead } from "../types/Lead";

interface Props {
  lead: Lead;
  onAccept?: (id: number) => void;
  onDecline?: (id: number) => void;
}

export default function LeadCard({ lead, onAccept, onDecline }: Props) {
  const isAccepted = lead.status === "accepted";
  const firstLetter = lead.firstName.charAt(0).toUpperCase();

  let formattedDate = "Invalid Date";
  try {
    formattedDate = new Date(lead.createdAt).toLocaleString("en-US", {
      month: "long",
      day: "numeric",
      hour: "numeric",
      minute: "2-digit",
      hour12: true,
    }).replace(",", "").replace("AM", "am").replace("PM", "pm");
  } catch {
    console.error("Erro ao formatar data:", lead.createdAt);
  }

  return (
    <div className="bg-white border rounded-md shadow-sm p-4 mb-4">
      {/* Header */}
      <div className="flex items-start gap-4 mb-2">
        <div className="bg-gray-400 text-white font-bold w-10 h-10 flex items-center justify-center rounded-full text-sm">
          {firstLetter}
        </div>
        <div className="flex-1">
          <h3 className="text-base font-semibold leading-tight">{lead.firstName}</h3>
          <p className="text-xs text-gray-500">{formattedDate}</p>
        </div>
      </div>

      {/* Info */}
      <div className="text-sm text-gray-700 flex flex-wrap gap-x-4 gap-y-1 mb-4">
        <span>📍 {lead.suburb}</span>
        <span>🧰 {lead.category}</span>
        <span>📄 Job ID: {lead.id}</span>
        {isAccepted && (
          <span className="text-gray-800">
            <strong>${lead.price.toFixed(2)}</strong> Lead Invitation
          </span>
        )}
      </div>

      {/* Contact info (only if accepted) */}
      {isAccepted && (
        <div className="text-sm text-orange-600 font-semibold mt-2 mb-4 flex flex-wrap gap-4">
          <span>📞 {lead.phone}</span>
          <span>✉️ {lead.email}</span>
        </div>
      )}

      {/* Description */}
      <p className="text-sm text-gray-600 whitespace-pre-line mb-5">{lead.description}</p>

      {/* Actions (only if not accepted) */}
      {!isAccepted && onAccept && onDecline && (
        <div className="flex items-center justify-left gap-4">
          <div className="space-x-2">
            <button
              onClick={() => onAccept(lead.id)}
              className="bg-orange-500 text-white px-4 py-1 rounded hover:bg-orange-600"
            >
              Accept
            </button>
            <button
              onClick={() => onDecline(lead.id)}
              className="bg-gray-300 text-gray-800 px-4 py-1 rounded hover:bg-gray-400"
            >
              Decline
            </button>
          </div>
          <span className="text-gray-800 text-sm">
            <strong>${lead.price.toFixed(2)}</strong> Lead Invitation
          </span>
        </div>
      )}
    </div>
  );
}
