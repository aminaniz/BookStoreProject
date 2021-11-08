import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Landingcard1Component } from './landingcard1.component';

describe('Landingcard1Component', () => {
  let component: Landingcard1Component;
  let fixture: ComponentFixture<Landingcard1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Landingcard1Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Landingcard1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
