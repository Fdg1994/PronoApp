import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { CompanyDetailsComponent } from './company-details/company-details.component';
import { EventDetailsComponent } from './event-details/event-details.component';
import { HomeComponent } from './home/home.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { UserBetsComponent } from './user-bets/user-bets.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path:'',component: HomeComponent},
  {path:'members',component: MemberListComponent,
    children: [
      {
          path:':id',
          component: MemberDetailComponent
      }     
    ]
  },
  {path:'companies',
    children: [
      {
          path:':id',
          component: CompanyDetailsComponent
      }     
    ]
  },
  {path:'bets',
  children: [
    {
        path:':id',
        component: UserBetsComponent
    }     
  ]
},
  {path:'events',
  children: [
    {
        path:':id',
        component: EventDetailsComponent
    }     
  ]
},
  {path:'admin',component: AdminPanelComponent,canActivate:[AuthGuard]},
  {path:'**',component: HomeComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
