import { RationalInfo } from "./RationalInfo";
import { ThesisPlan } from "./ThesisPlan";
import { WorkPlan } from "./WorkPlan";
import { EducationPhase } from "./EducationPhase";

export class GJournal {
    public Id: number;

    public GraduateId: number;

    public RationalInfo: RationalInfo;
    public ThesisPlan: ThesisPlan;

    public WorkPlans: WorkPlan[];
    public EducationYears: EducationPhase[];
}
