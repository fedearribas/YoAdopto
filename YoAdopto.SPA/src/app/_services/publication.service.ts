import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '../../../node_modules/@angular/common/http';
import { PaginatedResult } from '../_models/pagination';
import { Publication } from '../_models/publication';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PublicationService {

  baseUrl = environment.apiUrl + 'publications';

  constructor(private authHttp: HttpClient) { }

  getPublications(pageNumber?, itemsPerPage?, publicationParams?: any) {
    const paginatedResult: PaginatedResult<Publication[]> = new PaginatedResult<Publication[]>();
    let params = new HttpParams();

    if (pageNumber != null && itemsPerPage != null) {
      params = params.append('pageNumber', pageNumber);
      params = params.append('itemsPerPage', itemsPerPage);
    }

    if (publicationParams != null) {
      params = params.append('publicationType', publicationParams.publicationType);
      params = params.append('orderBy', publicationParams.orderBy);
    }

    return this.authHttp
      .get<Publication[]>(this.baseUrl, {observe: 'response', params })
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          console.log(response.body);

          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }

          return paginatedResult;
        })
      );
  }

}
