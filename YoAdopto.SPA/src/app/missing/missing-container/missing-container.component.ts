import { Component, OnInit } from '@angular/core';
import { Publication } from '../../_models/publication';
import { Pagination } from '../../_models/pagination';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-missing-container',
  templateUrl: './missing-container.component.html',
  styleUrls: ['./missing-container.component.css']
})
export class MissingContainerComponent implements OnInit {
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
