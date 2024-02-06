import { Component, Input, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CalendarService } from 'src/app/services/calendar.service';
import { Country } from 'src/app/shared/enums/country';
import { PublicHoliday } from '../models/public-holiday';

@Component({
  selector: 'app-public-holiday-display-page',
  templateUrl: './public-holiday-display-page.component.html',
  styleUrls: ['./public-holiday-display-page.component.css']
})
export class PublicHolidayDisplayPageComponent implements OnInit {
  holidays: PublicHoliday[];
  subscription: Subscription[] = [];
  @Input() sprintId: number;

  constructor(private calendarService: CalendarService){}

  ngOnInit(): void {
  }

   ngOnChanges() {
    if(this.sprintId) {
      this.getPublicHolidaysBySprintId(this.sprintId);
    }
  }

  ngOnDestroy() {
    this.subscription.forEach(s => s.unsubscribe());
  }

  getPublicHolidaysBySprintId(sprintId: number) {
    this.subscription.push(this.calendarService.getPublicHolidays(sprintId).subscribe(x => this.holidays = x));
  }
}
