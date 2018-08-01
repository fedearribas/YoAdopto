import { Pagination } from './../_models/pagination';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '../../../node_modules/@angular/router';
import { Publication } from '../_models/publication';

@Component({
  selector: 'app-missing',
  templateUrl: './missing.component.html',
  styleUrls: ['./missing.component.css']
})
export class MissingComponent implements OnInit {
  missing: Publication[];
  pagination: Pagination;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.missing = data['publications'].result;
      this.pagination = data['publications'].pagination;
    });
  }

}
