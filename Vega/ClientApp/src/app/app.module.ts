import { VehicleService } from './services/vehicle.service';
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import { VehicleReactiveFormComponent } from './components/vehicle-reactive-form/vehicle-reactive-form.component';
import { PropertiesArrayPipe } from './pipes/properties-array.pipe';

@NgModule({
  declarations: [
    AppComponent,
    VehicleFormComponent,
    VehicleReactiveFormComponent,
    PropertiesArrayPipe
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    VehicleService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
