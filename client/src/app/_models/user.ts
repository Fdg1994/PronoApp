import { Company } from "./company";

export interface User {
    username: string;
    password: string;
    companyid: number;
    company: Company;
    companyrole: string;
    token: string;
    role: string;
    points: number;
}

