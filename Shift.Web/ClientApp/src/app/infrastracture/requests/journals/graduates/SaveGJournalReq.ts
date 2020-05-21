import { GJournal } from "../../../entities/gjournal/GJournal";
import { BasePostRequest } from "../../BasePostRequest";

export class SaveGJournalReq extends BasePostRequest {
    journal: GJournal;

    constructor(journal: GJournal) {
        super();
        this.journal = journal;
    }

    get Body (): any {
        let journalJson = JSON.stringify(this.journal);
        return journalJson;
    }
    get TargetReqUrl (): string {
        return 'api/graduate/journal';
    }
}