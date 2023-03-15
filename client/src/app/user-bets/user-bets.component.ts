import { Component, OnInit } from '@angular/core';
import { Bet } from '../_models/bet';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-user-bets',
  templateUrl: './user-bets.component.html',
  styleUrls: ['./user-bets.component.css']
})
export class UserBetsComponent implements OnInit {
  user: User = {} as User;

  constructor(public accountService:AccountService) { }

  ngOnInit(): void {
    
  }
}
