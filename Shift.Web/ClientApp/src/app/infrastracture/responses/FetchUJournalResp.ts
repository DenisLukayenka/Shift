import { BaseResponse } from "./BaseResponse";
import { UJournal } from "../entities/UJournal";

export class FetchUJournalResp extends BaseResponse {
    UJournal: UJournal;
}