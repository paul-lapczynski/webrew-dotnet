import { Component, OnInit, Input } from '@angular/core';
import { Beer } from '../../../shared/models/beer';

@Component({
  selector: 'display-card',
  templateUrl: './display-card.component.html',
  styleUrls: ['./display-card.component.scss']
})
export class DisplayCardComponent implements OnInit {
  @Input() beer: Beer;
  constructor() { }

  ngOnInit() {
  }

}
