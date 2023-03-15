import { Component, EventEmitter, Output  } from '@angular/core';
import { EventService } from 'src/app/_services/event.service';


@Component({
  selector: 'app-event-form',
  templateUrl: './event-form.component.html',
  styleUrls: ['./event-form.component.css']
})
export class EventFormComponent {
  eventName: string = '';
  eventLogo: string = '';
  @Output() onCancel = new EventEmitter();

  visible: boolean = false;

  constructor(private eventService: EventService) {}

  onSubmit() {
    this.eventService.addEvent(this.eventName,this.eventLogo)

    this.visible = false;
  }

  onCancelClick() {
    this.onCancel.emit();
  }


}
