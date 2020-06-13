import { Protocol } from "../university/Protocol";

export class ThesisCertification {
    ThesisCertificationId: number;
    IsApproved: boolean;
    Mark: number;
    ApproveDate: Date;
    PreliminaryApproveDate: Date;
    DepartmentHead: string;
    UndergraduateJournalId?: number;
    PreliminaryResult: string;

    ProtocolId: number;
    Protocol: Protocol;
}