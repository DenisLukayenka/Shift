import { HttpParams } from "@angular/common/http";
import { BaseGetRequest } from "../../BaseGetRequest";

export class FetchUJournalReq extends BaseGetRequest {
    userId: number;

    constructor(userId: number) {
        super();
        this.userId = userId;
    }

    get TargetReqUrl (): string {
        return 'api/undergraduate/journal'
    }

    get Options() {
        return {
            params: new HttpParams().set('userId', this.userId.toString())
        };
    }
}