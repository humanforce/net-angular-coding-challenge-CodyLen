import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PublicHoliday } from '../components/public-holiday/models/public-holiday';

@Injectable({
  providedIn: 'root'
})
export class CalendarService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  getPublicHolidays(sprintId: number): Observable<PublicHoliday[]> {
    return this.http.get<PublicHoliday[]>(this.baseApiUrl + `/calendar/getpublicholidays?sprintId=${sprintId}`)
  }
}
