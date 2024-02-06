import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JiraTicketCardComponent } from './jira-ticket-card.component';

describe('JiraTicketCardComponent', () => {
  let component: JiraTicketCardComponent;
  let fixture: ComponentFixture<JiraTicketCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JiraTicketCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JiraTicketCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
