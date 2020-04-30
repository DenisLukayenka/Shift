import { BaseRequest } from "./BaseRequest";
import { RequestType } from "./requestType";
import * as _ from 'lodash';
import { UViewModel } from "../entities/auth/UViewModel";
import { castEducationForm } from "../utilities/castEducationForm";

export class RegisterUReq extends BaseRequest {
    UViewModel: UViewModel;

    constructor(undergraduate: UViewModel) {
        super();

        this.UViewModel = undergraduate;
    }

    get ReqType (): RequestType {
        return RequestType.POST;
    }
    get Body (): any {
        var element =_.assign({ EducationForm: castEducationForm(this.UViewModel.EducationForm) }, this.UViewModel);
        return JSON.stringify(element);
    }
    get TargetReqUrl (): string {
        return 'api/auth/register/undergraduate';
    }
}