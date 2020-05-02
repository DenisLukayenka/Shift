import { BaseRequest } from "./BaseRequest";
import { RequestType } from "./requestType";
import { UJournal } from "../entities/ujournal/UJournal";

export class SaveUJournalReq extends BaseRequest {
    public journal: UJournal;

    constructor(journal: UJournal) {
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
        return 'api/undergraduate/journal';
    }
}