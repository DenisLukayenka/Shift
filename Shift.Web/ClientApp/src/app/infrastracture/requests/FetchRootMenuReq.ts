import { ReqOptions } from "./ReqOptions";
import { HttpParams } from "@angular/common/http";
import { BaseGetRequest } from "./BaseGetRequest";

export class FetchRootMenuReq extends BaseGetRequest {
    UserId: number;

    constructor(userId: number) {
        super();
        this.UserId = userId;
    }

    get TargetReqUrl (): string {
        return 'api/RootMenu';
    }

    get Options (): ReqOptions {
        const params = new HttpParams()
            .set('UserId', this.UserId.toString());
            
        return {
            params: params
        };
    }
}