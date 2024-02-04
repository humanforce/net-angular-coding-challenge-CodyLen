import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryPublicHolidayCardComponent } from './country-public-holiday-card.component';

describe('CountryPublicHolidayComponentComponent', () => {
  let component: CountryPublicHolidayCardComponent;
  let fixture: ComponentFixture<CountryPublicHolidayCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CountryPublicHolidayCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CountryPublicHolidayCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
