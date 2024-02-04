import { Component, Input } from '@angular/core';
import { Subscription } from 'rxjs';
import { TicketService } from 'src/app/services/ticket.service';
import { TicketModel } from '../models/ticket-model';

@Component({
  selector: 'app-jira-ticket-card',
  templateUrl: './jira-ticket-card.component.html',
  styleUrls: ['./jira-ticket-card.component.css']
})
export class JiraTicketCardComponent {
  @Input() ticket: TicketModel;
  startDate: string;
  endDate: string;

  constructor() {}

  ngOnInit(): void {
    this.startDate = new Date(this.ticket.startDate).toLocaleDateString();
    this.endDate = new Date(this.ticket.endDate).toLocaleDateString();
  }

}
