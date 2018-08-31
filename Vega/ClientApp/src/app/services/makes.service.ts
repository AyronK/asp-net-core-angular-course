import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiSettings } from '../utils/api-settings';

@Injectable({
  providedIn: 'root'
})
export class MakesService {

  constructor(private http: HttpClient) {
  }

  getMakes(): Observable<any> {
    return this.http.get(ApiSettings.MAKES_ENDPOINT);    
  }
}
