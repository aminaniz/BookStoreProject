import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Similarcard1Component } from './similarcard1.component';

describe('Similarcard1Component', () => {
  let component: Similarcard1Component;
  let fixture: ComponentFixture<Similarcard1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Similarcard1Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Similarcard1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
