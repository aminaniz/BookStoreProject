import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BooksbycatComponent } from './booksbycat.component';

describe('BooksbycatComponent', () => {
  let component: BooksbycatComponent;
  let fixture: ComponentFixture<BooksbycatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BooksbycatComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BooksbycatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
