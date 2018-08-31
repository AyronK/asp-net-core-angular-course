import { FeaturesService } from './../../services/features.service';
import { MakesService } from './../../services/makes.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.scss']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  features: any[];

  vehicle: any = {};

  constructor(private makesSertive: MakesService, private featuresService: FeaturesService) {
  }

  ngOnInit() {
    this.makesSertive.getMakes().subscribe((resp) => this.makes = resp);
    this.featuresService.getFeatures().subscribe((resp) => { this.features = resp });
  }

  onMakeChange() {
    const selectedMake = this.makes.find((m) => m.id == this.vehicle.make);
    this.models = selectedMake ? selectedMake.models : [];
  }

}
