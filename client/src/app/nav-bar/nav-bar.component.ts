import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  user: User = {} as User;

  constructor(public accountService:AccountService,private router: Router,private toastr: ToastrService) { }

  ngOnInit(): void {
  }


  login() {
    this.accountService.login(this.user).subscribe({
      next: response => {
        console.log(response);
        this.user.role = response.role;
        console.log(this.user);
      },
      error: error => this.toastr.error(error.error)      
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
