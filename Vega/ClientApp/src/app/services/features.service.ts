import { ApiSettings } from './../utils/api-settings';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FeaturesService {

  constructor(private http: HttpClient) { }

  getFeatures() : Observable<any>{
    return this.http.get(ApiSettings.FEATURES_ENDPOINT);
  }
}
