import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Company } from '../_models/company';
import { User } from '../_models/user';
import { Event } from '../_models/event';
import { CompanyService } from '../_services/company.service';
import { EventService } from '../_services/event.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  companies: Company[] = [];
  events: Event[] = [];
  users: User[] = [];
  registerMode=false;

  constructor(private http: HttpClient, private companyService: CompanyService,private eventService: EventService) { }

  ngOnInit(): void {
   this.getCompanies();
   this.getEvents();
   console.log(this.companies);
  }

  getCompanies() {
    this.companyService.getCompanies().subscribe(companies => {
      this.companies = companies;
    });
  }

  getEvents() {
    this.eventService.getEvents().subscribe(events => {
    this.events = events;
    });
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

}
