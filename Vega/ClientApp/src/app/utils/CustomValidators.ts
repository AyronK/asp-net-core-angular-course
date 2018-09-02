import { AbstractControl, ValidationErrors, FormGroup, FormArray } from "@angular/forms";

export class CustomValidators {

    static atLeastOneInArraySelected(formArray: FormArray): ValidationErrors | null {
        for (const controlName in formArray.value) {
            if (formArray.value.hasOwnProperty(controlName)) {
                const value = formArray.value[controlName];

                if (value)
                    return null;
            }
        }
        return { atLeastOneFeatureSelected: true };
    }
}