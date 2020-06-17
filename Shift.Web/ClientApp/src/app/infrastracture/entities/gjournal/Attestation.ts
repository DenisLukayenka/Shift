import { Protocol } from "../university/Protocol";

export class Attestation {
    public Id: number;
    public AttestationResult: string;

    public Adviser: string;
    public AdviserApproveDate: Date;
    public IsAdviserApproved: boolean;

    public DepartmentHead: string;
    public DepartmentHeadApproveDate: Date;
    public IsDepartmentHeadApproved: boolean;

    public TrainingtHead: string;
    public TrainingHeadApproveDate: Date;
    public IsTrainingHeadApproved: boolean;

    public DepartmentResult: string;
    public CommissionResult: string;

    public DepartmentProtocolId: number;
    public DepartmentProtocol: Protocol;

    public CommissionProtocolId: number;
    public CommissionProtocol: Protocol;

    public EducationPhaseId: number;
}