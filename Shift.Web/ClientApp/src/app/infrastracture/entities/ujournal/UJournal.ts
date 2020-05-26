import { PreparationInfo } from "./PreparationInfo";
import { ThesisCertification } from "./ThesisCertification";
import { Report } from "./Report";

export class UJournal {
    Id: number;
    UndergraduateId?: number;

    PreparationInfoId: number;
    PreparationInfo: PreparationInfo;
    
    ThesisCertificationId: number;
    ThesisCertification: ThesisCertification;
    ReportResults: Report[];
}
