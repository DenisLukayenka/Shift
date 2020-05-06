import { BaseRequest } from "./BaseRequest";
import { GJournal } from "../entities/gjournal/GJournal";
import { RequestType } from "./requestType";

export class SaveGJournalReq extends BaseRequest {
    journal: GJournal;

    constructor(journal: GJournal) {
        super();
        this.journal = journal;
    }

    get ReqType (): RequestType {
        return RequestType.POST;
    }
    get Body (): any {
        let journalJson = JSON.stringify(this.journal);
        return journalJson;
    }
    get TargetReqUrl (): string {
        return 'api/graduate/journal';
    }
}