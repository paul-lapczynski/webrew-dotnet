import { Component, OnInit, Input } from '@angular/core';
import { Review } from '../../../shared/models/review';

@Component({
  selector: 'review-card',
  templateUrl: './review-card.component.html',
  styleUrls: ['./review-card.component.scss']
})
export class ReviewCardComponent implements OnInit {
  @Input() review: Review;
  constructor() { }

  ngOnInit() {
  }

}
