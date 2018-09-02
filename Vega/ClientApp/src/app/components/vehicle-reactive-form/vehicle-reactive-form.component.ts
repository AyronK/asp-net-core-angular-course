import { CustomValidators } from './../../utils/CustomValidators';
import { element } from 'protractor';
import { FormControl, FormGroup, Validators, FormArray, FormBuilder, ValidationErrors } from '@angular/forms';
import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-reactive-form',
  templateUrl: './vehicle-reactive-form.component.html',
  styleUrls: ['./vehicle-reactive-form.component.scss']
})
export class VehicleReactiveFormComponent implements OnInit {
  makes: any[];
  models: any[];
  features: any[] = [];

  vehicleForm: FormGroup;

  constructor(private vehicleService: VehicleService, private formBuilder: FormBuilder) {
    this.vehicleService.getMakes().subscribe((resp) => this.makes = resp);
    this.vehicleService.getFeatures().subscribe((resp) => {
      this.features = resp;

      let featuresConfig = {};

      for (const feature in this.features) {
        if (this.features.hasOwnProperty(feature)) {
          const element = this.features[feature];
          featuresConfig[element.id] = new FormControl();
        }
      }

      this.vehicleForm.setControl("features", new FormArray(this.features.map(f => new FormControl(false)), CustomValidators.atLeastOneInArraySelected));
      console.log(this.vehicleForm);
    });
  }

  ngOnInit() {

    this.vehicleForm = new FormGroup({
      makeId: new FormControl(null, [Validators.required]),
      modelId: new FormControl(null, [Validators.required]),
      isRegistered: new FormControl(false),
      features: new FormArray([]),
      contact: new FormGroup({
        name: new FormControl(null, [Validators.required]),
        phone: new FormControl(null, [Validators.required]),
        email: new FormControl()
      })
    });
  }

  onMakeChange() {
    delete this.vehicleForm.value.modelId;
    const selectedMake = this.makes.find((m) => m.id == this.vehicleForm.value.makeId);
    this.models = selectedMake ? selectedMake.models : [];
    this.vehicleForm.updateValueAndValidity();
  }

  submit() {
    if (this.vehicleForm.valid) {
      const selectedFeatures = this.vehicleForm.value.features
        .map((v, i) => v ? this.features[i].id : null)
        .filter(v => v !== null);
      const vehicle = { ...this.vehicleForm.value };
      vehicle.features = selectedFeatures;

      this.vehicleService.addVehicle(vehicle).subscribe((resp) => {
        alert("Vehicle added");
        this.vehicleForm.reset();
      });
    } else {
      alert("form not valid");
    }
  }

}
