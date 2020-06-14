import { FormGroup, FormControl, AbstractControl, FormArray } from "@angular/forms";
import * as _ from 'lodash';
import { ViewMode } from "../entities/ViewMode";

export const generateForm = (object: any, key: string = null, viewMode: ViewMode = ViewMode.Student): AbstractControl => {
    if (_.isArray(object)) {
        let objArray = new FormArray([]);
        object.forEach(elem => {
            objArray.push(generateForm(elem));
        });

        return objArray;
    } else if (_.isObject(object)) {
        let objGroup = new FormGroup({});
        Object.keys(object).forEach(key => {
            objGroup.addControl(key, generateForm(object[key], key, viewMode));
        });

        return objGroup;
    }

    return generateFormControl(object, key, viewMode);
}

const isStudentControl = (key: string) => {
    return !(key.toLocaleLowerCase().includes('adviser') 
        || key.toLocaleLowerCase().includes('approve')
        || key.toLocaleLowerCase().includes('mark'));
}

const generateFormControl = (object: any, key: string, viewMode: ViewMode) => {
    let control = new FormControl(object);

    if ((viewMode === ViewMode.Student && !isStudentControl(key))
        || (viewMode === ViewMode.Adviser && isStudentControl(key))) {
        control.disable();
    }

    return control;
}