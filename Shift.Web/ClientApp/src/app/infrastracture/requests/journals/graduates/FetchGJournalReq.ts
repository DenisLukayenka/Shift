import { HttpParams } from "@angular/common/http";
import { BaseGetRequest } from "../../BaseGetRequest";

export class FetchGJournalReq extends BaseGetRequest {
    userId: number;

    constructor(userId: number) {
        super();
        this.userId = userId;
    }

    get TargetReqUrl (): string {
        return 'api/graduate/journal';
    }

    get Options() {
        return {
            params: new HttpParams().set('userId', this.userId.toString())
        };
    }
}