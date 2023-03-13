export interface Game {
    name: string;
    startTimeGame: Date;
    endTimeGame: Date;
    gamestatus: string;
    team1: string;
    team2: string;
    team1Score: number;
    team2Score: number;
    event: Event;
}