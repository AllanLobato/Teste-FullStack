export type LeadStatus = 'invited' | 'accepted' | 'declined';

export interface Lead {
  id: number;
  firstName: string;
  fullName: string;
  createdAt: string;
  suburb: string;
  category: string;
  description: string;
  price: number;
  phone: string;
  email: string;
  status: LeadStatus;
}