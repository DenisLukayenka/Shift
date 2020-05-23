import { PreparationInfo } from "./PreparationInfo";
import { ThesisCertification } from "./ThesisCertification";
import { Report } from "./Report";
import { UniversitySettings } from "../university/Settings";

export class UJournal {
    Id: number;
    UndergraduateId?: number;
    Settins: UniversitySettings;

    PreparationInfoId: number;
    PreparationInfo: PreparationInfo;
    
    ThesisCertificationId: number;
    ThesisCertification: ThesisCertification;
    ReportResults: Report[];
}