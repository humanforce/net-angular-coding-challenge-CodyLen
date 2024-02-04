import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PublicHolidayDisplayPageComponent } from './components/public-holiday/public-holiday-display-page/public-holiday-display-page.component';
import { JiraTicketDisplayPageComponent } from './components/tickets/jira-ticket-display-page/jira-ticket-display-page.component';
import { TeamVelocityComponent } from './components/tickets/team-velocity/team-velocity.component';

const routes: Routes = [
  {
    path: 'publicholiday',
    component: PublicHolidayDisplayPageComponent
  },
  {
    path: 'teamvelocity',
    component: TeamVelocityComponent
  },
    {
    path: 'tickets',
    component: JiraTicketDisplayPageComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
