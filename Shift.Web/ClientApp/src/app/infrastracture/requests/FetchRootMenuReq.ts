import { BaseRequest } from "./BaseRequest";
import { RequestType } from "../entities/requests/requestType";
import { ReqOptions } from "../entities/requests/ReqOptions";
import { HttpParams } from "@angular/common/http";

export class FetchRootMenuReq extends BaseRequest {
    Role: string;

    get ReqType (): RequestType {
        return RequestType.GET;
    }

    get TargetReqUrl (): string {
        return 'api/RootMenu';
    }

    get Body (): any {
        throw new Error( "Method not implemented." );
    }

    get Options (): ReqOptions {
        const params = new HttpParams()
            .set('role', this.Role);
            
        return {
            params: params
        };
    }

    constructor(role: string) {
        super();
        this.Role = role;
    }
}