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
  bets: Bet[] = [];

  constructor(public accountService:AccountService) { }

  ngOnInit(): void {
    this.accountService.currentUser$.subscribe(currentUser => {
      if (currentUser) {
        this.bets = currentUser.bets;
      }
    });
    console.log(this.bets);
  }
}
