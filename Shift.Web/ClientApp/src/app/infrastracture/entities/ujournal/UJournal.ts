import { PreparationInfo } from "./PreparationInfo";
import { ThesisCertification } from "./ThesisCertification";
import { Report } from "./Report";
import { UniversitySettings } from "../university/Settings";

export class UJournal {
    Id: number;
    UndergraduateId?: number;
    Settins: UniversitySettings;
    PreparationInfo: PreparationInfo;
    ThesisCertification: ThesisCertification;
    ReportResults: Report[];
}