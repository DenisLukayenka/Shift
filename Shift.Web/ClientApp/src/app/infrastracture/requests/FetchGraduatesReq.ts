import { BaseRequest } from "./BaseRequest";
import { RequestType } from "./requestType";
import { HttpParams } from "@angular/common/http";

export class FetchGraduatesReq extends BaseRequest {
    employeeId: number;

    constructor(employeeId: number) {
        super();
        this.employeeId = employeeId;
    }

    get ReqType (): RequestType {
        return RequestType.GET;
    }
    get Body (): any {
        throw new Error( "Method not implemented." );
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