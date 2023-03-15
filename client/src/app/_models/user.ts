import { Bet } from "./bet";
import { Company } from "./company";

export interface User {
    id: number;
    username: string;
    password: string;
    companyid: number;
    company: Company;
    companyrole: string;
    token: string;
    role: string;
    points: number;
    bets: Bet[];
}

