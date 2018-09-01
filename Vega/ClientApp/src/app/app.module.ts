import { VehicleService } from './services/vehicle.service';
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';

@NgModule({
  declarations: [
    AppComponent,
    VehicleFormComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [
    VehicleService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
