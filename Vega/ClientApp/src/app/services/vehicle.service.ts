import { ApiSettings } from './../utils/api-settings';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  
  constructor(private http: HttpClient) { }

  getFeatures() : Observable<any>{
    return this.http.get(ApiSettings.FEATURES_ENDPOINT);
  }

  getMakes(): Observable<any> {
    return this.http.get(ApiSettings.MAKES_ENDPOINT);    
  }

  addVehicle(vehicle: any): Observable<any> {
    return this.http.post(ApiSettings.VEHICLES_ENDPOINT, vehicle);
  }
}
