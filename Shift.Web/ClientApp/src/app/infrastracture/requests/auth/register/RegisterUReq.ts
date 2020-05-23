import * as _ from 'lodash';
import { UndergraduateRegisterVM } from "../../../entities/auth/UndergraduateRegisterVM";
import { castEducationForm } from "../../../utilities/castEducationForm";
import { BasePostRequest } from "../../BasePostRequest";

export class RegisterUReq extends BasePostRequest {
    UndergraduateVM: UndergraduateRegisterVM;

    constructor(undergraduate: UndergraduateRegisterVM) {
        super();
        this.UndergraduateVM = undergraduate;
    }

    get Body (): any {
        return JSON.stringify(this.UndergraduateVM);
    }

    TargetReqUrl: string = 'api/auth/register/undergraduate';
}