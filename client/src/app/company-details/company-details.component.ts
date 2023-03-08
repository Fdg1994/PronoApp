import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Company } from '../_models/company';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';
import { CompanyService } from '../_services/company.service';

@Component({
  selector: 'app-company-details',
  templateUrl: './company-details.component.html',
  styleUrls: ['./company-details.component.css']
})
export class CompanyDetailsComponent implements OnInit {
  company: Company = {} as Company;
  currentUser: User = {} as User;

  constructor(public companyService: CompanyService, public accountService: AccountService, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void {
    const companyId = this.route.snapshot.paramMap.get('id') as string;
    this.companyService.getCompanyById(companyId).subscribe(company => {
      this.company = company;
    });
  }
}
