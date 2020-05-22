import { FormGroup, FormArray, FormControl } from "@angular/forms";
import * as _ from 'lodash';

export const markGroupAsDirty = (group: FormGroup) => {
    Object.keys(group.controls).forEach(key => {
        switch(group.get(key).constructor.name) {
            case 'FormGroup':
                markGroupAsDirty(group.get(key) as FormGroup);
                break;
            case 'FormArray':
                markArrayAsDirty(group.get(key) as FormArray);
                break;
            case 'FormControl':
                markControlAsDirty(group.get(key) as FormControl);
                break;
        }
    });
}

export const markArrayAsDirty = (array: FormArray) => {
    array.controls.forEach(control => {
        switch (control.constructor.name) {
            case "FormGroup":
                markGroupAsDirty(control as FormGroup);
                break;
            case "FormArray":
                markArrayAsDirty(control as FormArray);
                break;
            case "FormControl":
                markControlAsDirty(control as FormControl);
                break;
          }
    })
}

export const markControlAsDirty = (control: FormControl) => {
    control.markAsDirty();
}