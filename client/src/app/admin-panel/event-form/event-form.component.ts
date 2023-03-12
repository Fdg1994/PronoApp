import { Component, EventEmitter, Output  } from '@angular/core';
import { EventService } from 'src/app/_services/event.service';


@Component({
  selector: 'app-event-form',
  templateUrl: './event-form.component.html',
  styleUrls: ['./event-form.component.css']
})
export class EventFormComponent {
  eventName: string = '';
  eventDate: string = '';
  eventLocation: string = '';
  @Output() onCancel = new EventEmitter();

  visible: boolean = false;

  constructor(private eventService: EventService) {}

  onSubmit() {
    const formData = new FormData();
    formData.append('event-name', this.eventName);
    formData.append('event-date', this.eventDate);
    formData.append('event-location', this.eventLocation);

    // TODO: Send form data to server using HttpClient

    this.visible = false;
  }

  onCancelClick() {
    this.onCancel.emit();
  }
}
