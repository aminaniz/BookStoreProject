import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Landingcard3Component } from './landingcard3.component';

describe('Landingcard3Component', () => {
  let component: Landingcard3Component;
  let fixture: ComponentFixture<Landingcard3Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Landingcard3Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Landingcard3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
