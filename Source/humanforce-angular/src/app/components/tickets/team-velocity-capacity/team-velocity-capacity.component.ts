import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, SimpleChanges } from '@angular/core';
import { Subscription } from 'rxjs';
import { TicketService } from 'src/app/services/ticket.service';
import { SprintModel } from '../models/sprint-model';

@Component({
  selector: 'app-team-velocity-capacity',
  templateUrl: './team-velocity-capacity.component.html',
  styleUrls: ['./team-velocity-capacity.component.css']
})
export class TeamVelocityCapacityComponent {
  velocity: number;
  capacity: number;
  @Input() sprintId: number;

  constructor(private ticketService: TicketService){}

  ngOnInit(): void {
  }

  ngOnChanges() {
    this.getTeamCapacity();
    if (this.sprintId >= 4) {
       this.getTeamVelocity();
    } else {
      this.velocity = 0;
    }
  }

  getTeamVelocity() {
    this.ticketService.getTeamVelocityPast3Sprints(this.sprintId).subscribe(x => this.velocity = x);
  }

  getTeamCapacity() {
    this.ticketService.getTeamCapacityBySprint(this.sprintId).subscribe(x => this.capacity = x);
  }
}
