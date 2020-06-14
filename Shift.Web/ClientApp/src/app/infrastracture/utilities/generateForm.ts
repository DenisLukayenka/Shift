import { FormBuilder, FormGroup, FormControl, AbstractControl, FormArray } from "@angular/forms";
import * as _ from 'lodash';

export const generateForm = (object: any): AbstractControl => {
    if (_.isArray(object)) {
        let objArray = new FormArray([]);
        object.forEach(elem => {
            objArray.push(generateForm(elem));
        });

        return objArray;
    } else if (_.isObject(object)) {
        let objGroup = new FormGroup({});
        Object.keys(object).forEach(key => {
            objGroup.addControl(key, generateForm(object[key]));
        });

        return objGroup;
    }

    return new FormControl(object);
}