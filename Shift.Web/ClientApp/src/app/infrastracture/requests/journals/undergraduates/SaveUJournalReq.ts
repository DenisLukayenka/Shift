import { UJournal } from "../../../entities/ujournal/UJournal";
import { BasePostRequest } from "../../BasePostRequest";

export class SaveUJournalReq extends BasePostRequest {
    public journal: UJournal;

    constructor(journal: UJournal) {
        super();
        this.journal = journal;
    }

    get Body (): any {
        let journalJson = JSON.stringify(this.journal);
        return journalJson;
    }
    get TargetReqUrl (): string {
        return 'api/undergraduate/journal';
    }
}