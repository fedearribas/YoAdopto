import { PublicationPhoto } from './publicationPhoto';

export interface Publication {
  id: number;
  title: string;
  description: string;
  publicationType: number;
  publicationPhotos?: PublicationPhoto[];
  photoUrls?: string[];
}
