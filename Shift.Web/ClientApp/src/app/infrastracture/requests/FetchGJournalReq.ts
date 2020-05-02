import { BaseRequest } from "./BaseRequest";
import { RequestType } from "./requestType";
import { HttpParams } from "@angular/common/http";

export class FetchGJournalReq extends BaseRequest {
    userId: number;

    constructor(userId: number) {
        super();
        this.userId = userId;
    }

    get ReqType (): RequestType {
        return RequestType.GET;
    }
    get Body (): any {
        throw new Error( "Method not implemented." );
    }
    get TargetReqUrl (): string {
        return 'api/graduate/journal';
    }

    get Options() {
        const params = new HttpParams().set('userId', this.userId.toString());
        
        return {
            params: params
        };
    }
}