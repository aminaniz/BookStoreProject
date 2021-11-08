import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Landingcard2Component } from './landingcard2.component';

describe('Landingcard2Component', () => {
  let component: Landingcard2Component;
  let fixture: ComponentFixture<Landingcard2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Landingcard2Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Landingcard2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
