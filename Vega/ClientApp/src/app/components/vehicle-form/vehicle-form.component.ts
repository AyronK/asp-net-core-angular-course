import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { VehicleService } from '../../services/vehicle.service';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.scss']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  features: any[];

  vehicle: any = {
    features: [],
    contact: {},
    isRegistered: "false"
  };

  constructor(private vehicleService: VehicleService) {
  }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe((resp) => this.makes = resp);
    this.vehicleService.getFeatures().subscribe((resp) => { this.features = resp });
  }

  onMakeChange() {
    const selectedMake = this.makes.find((m) => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
    delete this.vehicle.modelId;
  }

  onFeatureToggle(featureId: number, $event) {
    if ($event.target.checked)
      this.vehicle.features.push(featureId);
    else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit(form: NgForm) {
    if (form.valid) {
      this.vehicleService.addVehicle(this.vehicle).subscribe((resp) => {
        alert("Vehicle added");
        this.vehicle = {
          features: [],
          contact: {},
          isRegistered: "false"
        };
        form.reset();
      });
    } else {
      alert("form not valid");
    }
  }

}
