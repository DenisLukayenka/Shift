export class WorkStage {
    public Id: number;
    public JobInfo: string;

    public StartDate: Date;
    public FinishDate: Date;
    public SubmitDate: Date;
    public ApproveDate: Date;

    public IsSubmitted: boolean;
    public IsApproved: boolean;

    public Note: string;
    public WorkPlanId: number;
}