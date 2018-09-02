import { ReactiveFormBaseComponent } from './../reactive-form-base/reactive-form-base.component';
import { CustomValidators } from './../../utils/CustomValidators';
import { element } from 'protractor';
import { FormControl, FormGroup, Validators, FormArray } from '@angular/forms';
import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-reactive-form',
  templateUrl: './vehicle-reactive-form.component.html',
  styleUrls: ['./vehicle-reactive-form.component.scss']
})

export class VehicleReactiveFormComponent extends ReactiveFormBaseComponent {
  makes: any[];
  models: any[];
  features: any[];

  private get selectedFeatures() {
    return this.form.value.features
      .map((value, index) => value ? this.features[index].id : null)
      .filter(value => value !== null);
  }

  constructor(private vehicleService: VehicleService) {
    super();

    this.vehicleService.getMakes().subscribe((resp) => this.makes = resp);
    this.vehicleService.getFeatures().subscribe((resp) => {
      this.features = resp;
      const featuresControls = this.features.map(f => new FormControl(false));

      this.form = new FormGroup({
        makeId: new FormControl(
          null,
          Validators.required),
        modelId: new FormControl(
          null,
          Validators.required),
        isRegistered: new FormControl(false),
        features: new FormArray(
          featuresControls,
          CustomValidators.atLeastOneInArraySelected),
        contact: new FormGroup({
          name: new FormControl(
            null,
            Validators.required),
          phone: new FormControl(
            null,
            [
              Validators.required,
              Validators.pattern("[0-9]{9}")
            ]),
          email: new FormControl(
            null,
            Validators.email)
        })
      });
    });
  }

  ngOnInit() {
  }

  onMakeChange() {
    delete this.form.value.modelId;
    const selectedMake = this.makes.find((m) => m.id == this.form.value.makeId);
    this.models = selectedMake ? selectedMake.models : [];
    this.form.updateValueAndValidity();
  }

  submit() {
    if (this.form.valid) {

      const vehicle = { ...this.form.value };
      vehicle.features = this.selectedFeatures;

      this.vehicleService.addVehicle(vehicle).subscribe((resp) => {
        alert("Vehicle added");
        this.form.reset();
      });
    } else {
      this.markFormGroupTouched(this.form);
    }
  }

}
