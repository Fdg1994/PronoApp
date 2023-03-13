import { Game } from "./game";

export interface Event {
    id: number;
    name: string;
    logourl: string;
    games: Game[];
}