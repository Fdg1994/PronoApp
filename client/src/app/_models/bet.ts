import { Game } from "./game";
import { User } from "./user";

export interface Bet {
    openBetTime: Date;
    closeBetTime: Date;
    status: string;
    amount: number;
    prediction: string;
    user: User;
    game: Game;
}