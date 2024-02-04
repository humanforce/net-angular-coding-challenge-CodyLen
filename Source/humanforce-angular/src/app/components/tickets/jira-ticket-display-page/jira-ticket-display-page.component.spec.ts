import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JiraTicketDisplayPageComponent } from './jira-ticket-display-page.component';

describe('JiraTicketDisplayPageComponent', () => {
  let component: JiraTicketDisplayPageComponent;
  let fixture: ComponentFixture<JiraTicketDisplayPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JiraTicketDisplayPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JiraTicketDisplayPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
