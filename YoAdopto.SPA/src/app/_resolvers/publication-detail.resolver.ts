import { Publication } from './../_models/publication';
import { PublicationService } from './../_services/publication.service';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class PublicationDetailResolver implements Resolve<Publication> {

  constructor(private publicationService: PublicationService, private router: Router,
    private alertify: AlertifyService) {  }

  resolve(route: ActivatedRouteSnapshot): Observable<Publication> {
    return this.publicationService.getPublication(route.params['id'])
    .pipe(
      catchError(error => {
        this.alertify.error('Problem retrieving data');
        this.router.navigate(['/perdidos']);
        return of(null);
      })
    );
  }

}
