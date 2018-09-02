import { FormGroup } from '@angular/forms';
import { Component, OnInit, Injectable } from '@angular/core';

@Component({
  selector: 'app-reactive-form-base',
  template: ''
})

@Injectable()
export class ReactiveFormBaseComponent {

  form: FormGroup;

  protected markFormGroupTouched(formGroup: FormGroup) {
    (<any>Object).values(formGroup.controls).forEach(control => {
      control.markAsTouched();

      if (control.controls) {
        this.markFormGroupTouched(control);
      }
    });
  }

  public get controls() {
    return this.form.controls;
  }

  public hasError(control): boolean{
    return !control.valid && (control.dirty || control.touched);
  }

  constructor() {

  }
}
