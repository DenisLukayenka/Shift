import { BasePostRequest } from "../../BasePostRequest";
import { EmployeeRegisterVM } from "src/app/infrastracture/entities/auth/EmployeeRegisterVM";

export class RegisterEmployeeReq extends BasePostRequest {
    private employee: EmployeeRegisterVM;

    constructor(e: EmployeeRegisterVM) {
        super();
        this.employee = e;
    }

    TargetReqUrl: string = 'api/auth/register/employee';

    get Body(): any {
        return JSON.stringify(this.employee);
    }
}