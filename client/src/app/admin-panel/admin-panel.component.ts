import { Component, OnInit } from '@angular/core';
import { EventService } from '../_services/event.service';
import { Event } from '../_models/event';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {
  showForm = false;
  events: Event[] = [];

  constructor(private eventService: EventService) { }

  ngOnInit(): void {
    this.getEvents();
  }

  getEvents() {
    this.eventService.getEvents().subscribe(events => {
    this.events = events;
    });
  }

  onAddEventClick() {
    this.showForm = true;
  }

  hideForm() {
    this.showForm = false;
  }
}
