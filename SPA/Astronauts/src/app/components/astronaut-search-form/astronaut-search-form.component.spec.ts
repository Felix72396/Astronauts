import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AstronautSearchFormComponent } from './astronaut-search-form.component';

describe('AstronautSearchFormComponent', () => {
  let component: AstronautSearchFormComponent;
  let fixture: ComponentFixture<AstronautSearchFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AstronautSearchFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AstronautSearchFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
