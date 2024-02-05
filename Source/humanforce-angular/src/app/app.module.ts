import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CountryPublicHolidayCardComponent } from './components/public-holiday/country-public-holiday-card/country-public-holiday-card.component';
import { PublicHolidayDisplayPageComponent } from './components/public-holiday/public-holiday-display-page/public-holiday-display-page.component';
import { BarChartComponent } from './components/tickets/bar-chart/bar-chart.component';
import { HttpClientModule } from '@angular/common/http';
import { TeamVelocityCapacityComponent } from './components/tickets/team-velocity-capacity/team-velocity-capacity.component';
import { JiraTicketCardComponent } from './components/tickets/jira-ticket-card/jira-ticket-card.component';
import { JiraTicketDisplayPageComponent } from './components/tickets/jira-ticket-display-page/jira-ticket-display-page.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import {MatRadioModule} from '@angular/material/radio';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatDividerModule} from '@angular/material/divider';

@NgModule({
  declarations: [
    AppComponent,
    CountryPublicHolidayCardComponent,
    PublicHolidayDisplayPageComponent,
    BarChartComponent,
    TeamVelocityCapacityComponent,
    JiraTicketCardComponent,
    JiraTicketDisplayPageComponent,
    MainPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatRadioModule,
    FormsModule,
    ReactiveFormsModule,
    MatDividerModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
