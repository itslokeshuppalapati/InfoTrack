import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SearchHistoryService {

  constructor(private http: HttpClient) { }

  getAllSearchHistories() : Observable<any>  {
    return this.http.get(`${environment.apiEndpoint}/SearchHistory/All`);
  }
}
