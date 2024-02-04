import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { TicketService } from 'src/app/services/ticket.service';
import { TicketModel } from '../models/ticket-model';

@Component({
  selector: 'app-jira-ticket-display-page',
  templateUrl: './jira-ticket-display-page.component.html',
  styleUrls: ['./jira-ticket-display-page.component.css']
})
export class JiraTicketDisplayPageComponent {
  subcription: Subscription[] = [];
  tickets: TicketModel[];
  sprint = "SCRUM Sprint 10" //temp set up for now. in the future it should be dynamic variable taking from outside.
  constructor(private ticketService: TicketService){}

  ngOnInit(): void {
    this.getTeamCapacity();
  }

  ngOnDestroy() {
    this.subcription.forEach(s => s.unsubscribe());
  }

  getTeamCapacity() {

    this.subcription.push(this.ticketService.getTicketsBySprint(this.sprint).subscribe(x => {
      this.tickets = x
    }));
  }
}
