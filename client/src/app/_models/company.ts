import { User } from "./user";

export interface Company {
    id: number;
    name: string;
    pictureUrl: string;
    members: User[];
}