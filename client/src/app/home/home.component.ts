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
   console.log(this.companies);
  }

  getCompanies() {
    this.companyService.getCompanies().subscribe(companies => {
      this.companies = companies;
    });
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

}
