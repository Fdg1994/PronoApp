import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { RegisterFormComponent } from './register-form/register-form.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ToastrModule } from 'ngx-toastr';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { CompanyDetailsComponent } from './company-details/company-details.component';
import { UserBetsComponent } from './user-bets/user-bets.component';
import { EventDetailsComponent } from './event-details/event-details.component';
import { EventFormComponent } from './admin-panel/event-form/event-form.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomeComponent,
    RegisterFormComponent,
    MemberListComponent,
    MemberDetailComponent,
    AdminPanelComponent,
    CompanyDetailsComponent,
    UserBetsComponent,
    EventDetailsComponent,
    EventFormComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
