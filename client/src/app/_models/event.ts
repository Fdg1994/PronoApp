import { Game } from "./game";

export interface Event {
    name: string;
    games: Game[];
}