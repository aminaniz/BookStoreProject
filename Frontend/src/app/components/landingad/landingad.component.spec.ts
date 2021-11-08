import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LandingadComponent } from './landingad.component';

describe('LandingadComponent', () => {
  let component: LandingadComponent;
  let fixture: ComponentFixture<LandingadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LandingadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LandingadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
