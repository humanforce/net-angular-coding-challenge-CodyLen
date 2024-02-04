import { Component, OnInit } from '@angular/core';
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
  subcription: Subscription[] = [];

  constructor(private calendarService: CalendarService){}

  ngOnInit(): void {
    this.getPublicHoldayByCountry(Country.Australia);
  }

  ngOnDestroy() {
    this.subcription.forEach(s => s.unsubscribe());
  }

  getPublicHoldayByCountry(country: Country) {
    this.subcription.push(this.calendarService.getPublicHolidays(country).subscribe(x => this.holidays = x));
  }
}
