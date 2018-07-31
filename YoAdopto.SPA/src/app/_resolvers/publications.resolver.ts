import { Publication } from './../_models/publication';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { PublicationService } from '../_services/publication.service';

@Injectable()
export class PublicationsResolver implements Resolve<Publication[]> {
  pageSize = 5;
  pageNumber = 1;
  likesParam = 'Likers';

  publicationParams: any = {};

  constructor(private publicationService: PublicationService, private router: Router,
    private alertify: AlertifyService) {  }

  resolve(route: ActivatedRouteSnapshot): Observable<Publication[]> {
    console.log('resolving');

    this.publicationParams.publicationType = route.data['publicationType'];
    this.publicationParams.orderBy = 'createdAt';
    return this.publicationService.getPublications(this.pageNumber, this.pageSize, this.publicationParams)
    .pipe(
      catchError(error => {
        this.alertify.error('Problem retrieving data');
        this.router.navigate(['']);
        return of(null);
      })
    );
  }

}
