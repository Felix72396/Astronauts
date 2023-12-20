import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AstronautSocialMediaComponent } from './astronaut-social-media.component';

describe('AstronautSocialMediaComponent', () => {
  let component: AstronautSocialMediaComponent;
  let fixture: ComponentFixture<AstronautSocialMediaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AstronautSocialMediaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AstronautSocialMediaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
