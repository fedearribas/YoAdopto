import { Publication } from './publication';

export interface User {
  id: number;
  username: string;
  email: string;
  createdAt: Date;
  lastActive: Date;
  photoUrl: string;
  publications?: Publication[];
}
