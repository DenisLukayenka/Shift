import { CalendarStage } from "./CalendarStage";
import { ScienceActivity } from "./ScienceActivity";
import { Attestation } from "./Attestation";

export class EducationPhase {
    public Id: number;

    public TripsInternships: string;
    public SubWorks: string;

    public Publications: string;
    public ScienceParticipations: string;
    public SubResearchResults: string;

    public JournalId: number;

    public Adviser: string;
    public AdviserApproveDate: Date;
    public IsAdviserApproved: boolean;

    public SubmitDate: Date;
    public IsSubmitted: boolean;

    public CalendarStages: CalendarStage[];
    public ScienceActivities: ScienceActivity[];
    public Attestations: Attestation[];
}