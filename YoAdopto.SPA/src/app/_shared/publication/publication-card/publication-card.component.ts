import { Component, OnInit, Input } from '@angular/core';
import { Publication } from '../../../_models/publication';

@Component({
  selector: 'app-publication-card',
  templateUrl: './publication-card.component.html',
  styleUrls: ['./publication-card.component.css']
})
export class PublicationCardComponent implements OnInit {
  @Input() publication: Publication;
  constructor() { }

  ngOnInit() {
  }

}
