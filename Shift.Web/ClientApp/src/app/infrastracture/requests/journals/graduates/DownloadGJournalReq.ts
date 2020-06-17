import { BaseGetRequest } from "../../BaseGetRequest";
import { HttpParams, HttpHeaders } from "@angular/common/http";
import { ReqOptions } from "../../ReqOptions";

export class DownloadGJournalReq extends BaseGetRequest {
    userId: number;

    constructor(userId: number) {
        super();
        this.userId = userId;
    }

    get TargetReqUrl (): string {
        return 'api/graduate/journal/downloadJournal'
    }

    get Options() {
        let options = new ReqOptions();
        options.responseType = 'blob' as 'json';
        options.params = new HttpParams().set('userId', this.userId.toString());
        options.headers = new HttpHeaders().set('Content-Type', 'application/vnd.openxmlformats-officedocument.wordprocessingml.document');

        return options;
    }
}