import { ChangeDetectionStrategy, ChangeDetectorRef, Component, SimpleChanges } from '@angular/core';
import { Subscription } from 'rxjs';
import { TicketService } from 'src/app/services/ticket.service';
import { SprintModel } from '../models/sprint-model';

@Component({
  selector: 'app-team-velocity',
  templateUrl: './team-velocity.component.html',
  styleUrls: ['./team-velocity.component.css']
})
export class TeamVelocityComponent {
  velocity: number;
  capacity: number;
  subcription: Subscription[] = [];
  sprint = "SCRUM Sprint 10"; //temp set up for now. in the future it should be dynamic variable taking from outside.
  constructor(private ticketService: TicketService){}

  ngOnInit(): void {
    this.getTeamVelocity();
    this.getTeamCapacity();
  }

  ngOnDestroy() {
    this.subcription.forEach(s => s.unsubscribe());
  }

  getTeamVelocity() {
    this.subcription.push(this.ticketService.getTeamVelocityPast3Sprints(this.sprint).subscribe(x => this.velocity = x));
  }

  getTeamCapacity() {
    this.subcription.push(this.ticketService.getTeamCapacityBySprint(this.sprint).subscribe(x => this.capacity = x));

  }
}
