import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SprintModel } from '../components/tickets/models/sprint-model';
import { TicketModel } from '../components/tickets/models/ticket-model';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) {
  }

  getTeamVelocityPast3Sprints(sprint: string): Observable<number> {
    return this.http.get<number>(this.baseApiUrl + `/jiratickets/getvelocitypast3sprints?sprint=${sprint}`);
  }

  getTeamCapacityBySprint(sprint: string): Observable<number> {
    return this.http.get<number>(this.baseApiUrl + `/jiratickets/getcapacitybysprint?sprint=${sprint}`);
  }

  getTicketsBySprint(sprint: string): Observable<TicketModel[]> {
    return this.http.get<TicketModel[]>(this.baseApiUrl + `/jiratickets/gettickets?sprint=${sprint}`);
  }
}
