import { Publication } from './../../../_models/publication';
import { Component, OnInit, Output, Input } from '@angular/core';

@Component({
  selector: 'app-publication-list',
  templateUrl: './publication-list.component.html',
  styleUrls: ['./publication-list.component.css']
})
export class PublicationListComponent implements OnInit {

  @Input() publications: Publication[];

  constructor() { }

  ngOnInit() {
  }

}
