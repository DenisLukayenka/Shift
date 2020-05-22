import * as _ from 'lodash';
import { UndergraduateRegisterVM } from "../../../entities/auth/UndergraduateRegisterVM";
import { castEducationForm } from "../../../utilities/castEducationForm";
import { BasePostRequest } from "../../BasePostRequest";

export class RegisterUReq extends BasePostRequest {
    UViewModel: UndergraduateRegisterVM;

    constructor(undergraduate: UndergraduateRegisterVM) {
        super();

        this.UViewModel = undergraduate;
    }

    get Body (): any {
        var element =_.assign({ EducationForm: castEducationForm(this.UViewModel.EducationForm) }, this.UViewModel);
        return JSON.stringify(element);
    }

    get TargetReqUrl (): string {
        return 'api/auth/register/undergraduate';
    }
}