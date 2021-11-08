import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LandingsidebarComponent } from './landingsidebar.component';

describe('LandingsidebarComponent', () => {
  let component: LandingsidebarComponent;
  let fixture: ComponentFixture<LandingsidebarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LandingsidebarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LandingsidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
