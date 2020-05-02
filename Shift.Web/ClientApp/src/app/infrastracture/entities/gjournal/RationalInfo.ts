import { Protocol } from "../university/Protocol";

export class RationalInfo {
    public RationalInfoId: number;
    public StudyPurpose: string;
    public StudyObject: string;
    public StudySubject: string;
    public Justification: string;

    public ThesisPublications: string;
    public ResearchParticipation: string;
    public DissertationTopic: string;

    public DepartmentHead: string;
    public DepartmentHeadApproveDate: Date;
    public IsDepartmentHeadApproved: boolean;

    public TrainingHead: string;
    public TrainingHeadApproveDate: Date;
    public IsTrainingHeadApproved: boolean;

    public Adviser: string;
    public AdviserApproveDate: Date;
    public IsAdviserApproved: boolean;

    public Protocol: Protocol;

    public GraduateJournalId: number;
}