import { FormControl, FormGroup, Validators, FormArray, FormBuilder } from '@angular/forms';
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
  features: any[];

  vehicleForm: FormGroup;

  vehicle: any = {
    features: [],
    contact: {},
    isRegistered: "false"
  };

  constructor(private vehicleService: VehicleService, private formBuilder: FormBuilder) {
    this.vehicleService.getMakes().subscribe((resp) => this.makes = resp);
    this.vehicleService.getFeatures().subscribe((resp) => {
      this.features = resp;
      let featuresGroup = {};

      for (const feature in this.features) {
        if (this.features.hasOwnProperty(feature)) {
          const element = this.features[feature];
          featuresGroup[element.name] = new FormControl();
        }
      }

      this.vehicleForm.setControl("features", new FormGroup(featuresGroup));
    });
  }

  ngOnInit() {

    this.vehicleForm = new FormGroup({
      makeId: new FormControl(null, [Validators.required]),
      modelId: new FormControl(null, [Validators.required]),
      isRegistered: new FormControl(false),
      features: new FormGroup({ }),
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
  }

  submit(form: FormGroup) {
     console.log(form.value);
    // if (form.valid) {
    //   this.vehicleService.addVehicle(this.vehicle).subscribe((resp) => {
    //     alert("Vehicle added");
    //     this.vehicle = {
    //       features: [],
    //       contact: {},
    //       isRegistered: "false"
    //     };
    //     form.reset();
    //   });
    // } else {
    //   alert("form not valid");
    // }
  }

}
