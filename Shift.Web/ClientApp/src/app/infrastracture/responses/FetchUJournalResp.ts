import { BaseResponse } from "./BaseResponse";
import { UJournal } from "../entities/UJournal";

export class FetchUJournalResp extends BaseResponse {
    static fullName = 'FetchUJResp';
    Type = FetchUJournalResp.fullName;

    UJournal: UJournal;
}