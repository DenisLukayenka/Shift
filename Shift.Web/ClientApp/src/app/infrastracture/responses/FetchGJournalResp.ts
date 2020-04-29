import { BaseResponse } from "./BaseResponse";
import { GJournal } from "../entities/GJournal";

export class FetchGJournalResp extends BaseResponse {
    GJournal: GJournal;
}