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

  getTeamVelocityPast3Sprints(sprintId: number): Observable<number> {
    return this.http.get<number>(this.baseApiUrl + `/jiratickets/getvelocity?sprintId=${sprintId}`);
  }

  getTeamCapacityBySprint(sprintId: number): Observable<number> {
    return this.http.get<number>(this.baseApiUrl + `/jiratickets/getcapacity?sprintId=${sprintId}`);
  }

  getTicketsBySprint(sprintId: number): Observable<TicketModel[]> {
    return this.http.get<TicketModel[]>(this.baseApiUrl + `/jiratickets/gettickets?sprintId=${sprintId}`);
  }
}
