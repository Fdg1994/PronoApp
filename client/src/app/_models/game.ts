export interface Game {
    name: string;
    startTime: Date;
    endTime: Date;
    gamestatus: string;
    team1: string;
    team2: string;
    team1Score: number;
    team2Score: number;
    event: Event;
}