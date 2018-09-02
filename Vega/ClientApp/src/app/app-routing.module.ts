import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import { VehicleReactiveFormComponent } from './components/vehicle-reactive-form/vehicle-reactive-form.component';

const routes: Routes = [
  { path: 'vehicles/new', component: VehicleFormComponent },
  { path: 'vehicles/newRx', component: VehicleReactiveFormComponent },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
