import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  getRankings(searchText: any, searchEngineId: any) : Observable<any> {
    const params = new HttpParams()
      .set('searchText', searchText)
      .set('searchEngineId', searchEngineId)
      .set('pageSize', 100);
    return this.http.get(`${environment.apiEndpoint}/Search/Rankings`, {params}).pipe(
      catchError((response: HttpErrorResponse) => {
        throw throwError(response);
      })
    );
  }

  constructor(private http: HttpClient) { }

  getSearchEngines() : Observable<any>  {
    return this.http.get(`${environment.apiEndpoint}/Search/SearchEngines`);
  }
}