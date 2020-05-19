import { HttpParams } from "@angular/common/http";
import { BaseGetRequest } from "./BaseGetRequest";

export class FetchGraduatesReq extends BaseGetRequest {
    employeeId: number;

    constructor(employeeId: number) {
        super();
        this.employeeId = employeeId;
    }

    get TargetReqUrl (): string {
        return 'api/employee/graduates';
    }

    get Options() {
        return {
            params: new HttpParams().set('userId', this.employeeId.toString())
        };
    }
}