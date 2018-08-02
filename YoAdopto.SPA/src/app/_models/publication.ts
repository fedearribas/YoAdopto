import { PublicationPhoto } from './publicationPhoto';

export interface Publication {
  id: number;
  title: string;
  description: string;
  publicationType: number;
  username: string;
  userId: number;
  createdAt: Date;
  state: string;
  city: string;
  contactPhone: string;
  contactEmail: string;
  photoUrls?: string[];
  photos?: PublicationPhoto[];
}
