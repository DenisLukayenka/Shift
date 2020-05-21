import { HttpParams } from "@angular/common/http";
import { BaseGetRequest } from "../BaseGetRequest";

export class FetchUndergraduatesReq extends BaseGetRequest {
    employeeId: number;

    constructor(employeeId: number) {
        super();
        this.employeeId = employeeId;
    }

    get TargetReqUrl (): string {
        return 'api/employee/undergraduates';
    }

    get Options() {
        return {
            params: new HttpParams().set('userId', this.employeeId.toString())
        };
    }
}