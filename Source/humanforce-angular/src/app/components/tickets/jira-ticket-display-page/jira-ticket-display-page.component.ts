import { Component, Input, SimpleChange } from '@angular/core';
import { Subscription } from 'rxjs';
import { TicketService } from 'src/app/services/ticket.service';
import { TicketModel } from '../models/ticket-model';

@Component({
  selector: 'app-jira-ticket-display-page',
  templateUrl: './jira-ticket-display-page.component.html',
  styleUrls: ['./jira-ticket-display-page.component.css']
})
export class JiraTicketDisplayPageComponent {
  @Input() sprintId: number;
  subscription: Subscription[] = [];
  tickets: TicketModel[];
  constructor(private ticketService: TicketService){}

  ngOnInit(): void {

  }

  ngOnChanges(changes: SimpleChange) {
    this.getTickets();
  }

  ngOnDestroy() {
    this.subscription.forEach(s => s.unsubscribe());
  }

  getTickets() {
    this.subscription.push(this.ticketService.getTicketsBySprint(this.sprintId).subscribe(x => {
      this.tickets = x;
    }));
  }
}
