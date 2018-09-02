import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleReactiveFormComponent } from './vehicle-reactive-form.component';

describe('VehicleReactiveFormComponent', () => {
  let component: VehicleReactiveFormComponent;
  let fixture: ComponentFixture<VehicleReactiveFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleReactiveFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleReactiveFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
