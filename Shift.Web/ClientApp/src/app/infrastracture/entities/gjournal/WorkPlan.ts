import { WorkStage } from "./WorkStage";

export class WorkPlan {
    public WorkPlanId: number;
    public IsSubmitted: boolean;
    public SubmitDate: Date;
    public Adviser: string;
    public AdviserApproveDate: Date;
    public IsAdviserApproved: boolean;

    public TrainingHead: string;
    public TrainingHeadApproveDate: Date;
    public IsTrainingHeadApproved: boolean;

    public FinalCertification: string;
    public CouncilNumber: string;
    public GraduateJournalId: number;
    public WorkStages: WorkStage[];
}