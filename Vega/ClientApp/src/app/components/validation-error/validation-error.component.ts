import { ValidationErrors } from '@angular/forms';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-validation-error',
  templateUrl: './validation-error.component.html',
  styleUrls: ['./validation-error.component.scss']
})
export class ValidationErrorComponent implements OnInit {

  @Input() errors: ValidationErrors;

  errorMessages: string[] = [];

  private static dictionary = {
    required: "Field is required",
    atLeastOneInArraySelected: "Selection is required"
  };

  constructor() {
  }

  ngOnInit() {
    for (const error in this.errors) {
      if (this.errors.hasOwnProperty(error)) {
        const translatedError = ValidationErrorComponent.dictionary[error];
        this.errorMessages.push(translatedError ? translatedError : error);
      }
    }
  }
}
