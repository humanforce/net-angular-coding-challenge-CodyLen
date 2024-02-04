import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PublicHolidayDisplayPageComponent } from './public-holiday-display-page.component';

describe('PublicHolidayDisplayPageComponent', () => {
  let component: PublicHolidayDisplayPageComponent;
  let fixture: ComponentFixture<PublicHolidayDisplayPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PublicHolidayDisplayPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PublicHolidayDisplayPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
