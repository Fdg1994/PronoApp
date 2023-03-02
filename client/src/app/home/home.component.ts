import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Company } from '../_models/company';
import { CompanyService } from '../_services/company.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  companies: Company[] = [];
  users: any;
  registerMode=false;

  constructor(private http: HttpClient, private companyService: CompanyService) { }

  ngOnInit(): void {
   this.getCompanies();
  }

  getUsers() {
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: response => this.users = response,
      error: error => console.log(error),
      complete: () => console.log('request has completed')
    });
  }

  getCompanies() {
    this.http.get('https://localhost:5001/api/companies').subscribe(data => {
      this.companies = <Company[]>data;
    });
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

}
