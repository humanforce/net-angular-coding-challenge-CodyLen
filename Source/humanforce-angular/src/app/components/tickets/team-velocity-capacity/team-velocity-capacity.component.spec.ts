import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamVelocityCapacityComponent } from './team-velocity-capacity.component';

describe('TeamVelocityCapacityComponent', () => {
  let component: TeamVelocityCapacityComponent;
  let fixture: ComponentFixture<TeamVelocityCapacityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeamVelocityCapacityComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TeamVelocityCapacityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
