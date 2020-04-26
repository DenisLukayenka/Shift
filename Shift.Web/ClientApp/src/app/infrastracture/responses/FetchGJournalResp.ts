import { BaseResponse } from "./BaseResponse";
import { GJournal } from "../entities/GJournal";

export class FetchGJournalResp extends BaseResponse {
    static fullName = 'FetchGJResp';
    Type = FetchGJournalResp.fullName;

    GJournal: GJournal;
}