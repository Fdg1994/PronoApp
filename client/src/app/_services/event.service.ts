import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Event } from '../_models/event'

@Injectable({
  providedIn: 'root'
})
export class EventService {

  constructor(private http: HttpClient) { }

  getEvents(): Observable<Event[]> {
    return this.http.get<Event[]>(environment.url + 'events').pipe(
      map(dto => dto.map(dto => ({
        id: dto.id,
        name:dto.name,
        logourl:dto.logourl,
        games:dto.games
      }) as Event))
    );
  }

  addEvent(eventName: string, eventLogo: string): Observable<Event> {
    const formData = new FormData();
    formData.append('event-name', eventName);
    formData.append('event-logo', eventLogo);

    return this.http.post<any>('/api/events', formData).pipe(
      map(dto => ({
        id: dto.id,
        name: dto.name,
        logourl: dto.logourl,
        games: dto.games
      }) as Event)
    );
  }

  removeEvent()
  {

  }

  addGameToEvent()
  {

  }
  
  removeGameFromEvent()
  {

  }

  updateGameFromEvent()
  {

  }
}