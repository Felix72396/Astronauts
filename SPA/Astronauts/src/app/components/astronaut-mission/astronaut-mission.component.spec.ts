import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AstronautMissionComponent } from './astronaut-mission.component';

describe('AstronautMissionComponent', () => {
  let component: AstronautMissionComponent;
  let fixture: ComponentFixture<AstronautMissionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AstronautMissionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AstronautMissionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
