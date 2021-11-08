import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LandingnavbarComponent } from './landingnavbar.component';

describe('LandingnavbarComponent', () => {
  let component: LandingnavbarComponent;
  let fixture: ComponentFixture<LandingnavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LandingnavbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LandingnavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
