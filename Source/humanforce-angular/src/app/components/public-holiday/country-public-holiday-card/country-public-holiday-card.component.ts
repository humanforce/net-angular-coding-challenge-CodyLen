import { Component, Input } from '@angular/core';
import { Country } from 'src/app/shared/enums/country';
import { PublicHoliday } from '../models/public-holiday';

@Component({
  selector: 'app-country-public-holiday-card',
  templateUrl: './country-public-holiday-card.component.html',
  styleUrls: ['./country-public-holiday-card.component.css']
})
export class CountryPublicHolidayCardComponent {
  @Input() publicHoliday: PublicHoliday;
}
