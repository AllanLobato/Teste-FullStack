import axios from 'axios';
import { api } from './api';

const API_URL = 'https://localhost:7194/api';

export const getLeadsByStatus = async (status: string) => {
  const res = await api.get(`/leads?status=${status}`);
  return res.data;
};

export async function acceptLead(id: number): Promise<void> {
  await axios.post(`${API_URL}/leads/${id}/accept`);
}

export async function declineLead(id: number): Promise<void> {
  await axios.post(`${API_URL}/leads/${id}/decline`);
}
