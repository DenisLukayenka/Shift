import { BaseRequest } from "./BaseRequest";
import { RequestType } from "./requestType";
import { ReqOptions } from "./ReqOptions";
import { HttpParams } from "@angular/common/http";

export class FetchRootMenuReq extends BaseRequest {
    UserId: number;

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
            .set('UserId', this.UserId.toString());
            
        return {
            params: params
        };
    }

    constructor(userId: number) {
        super();
        this.UserId = userId;
    }
}