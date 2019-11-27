import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BeerReviewComponent } from './beer-review.component';

describe('BeerReviewComponent', () => {
  let component: BeerReviewComponent;
  let fixture: ComponentFixture<BeerReviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BeerReviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BeerReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
