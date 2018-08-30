import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.scss']
})
export class VehicleFormComponent implements OnInit {

  constructor(private http: HttpClient) { 
    http.get("/api/makes").subscribe((resp)=>{
      console.log(resp);
    });
  }

  ngOnInit() {
  }

}
