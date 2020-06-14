import { RationalInfo } from "./RationalInfo";
import { ThesisPlan } from "./ThesisPlan";
import { WorkPlan } from "./WorkPlan";
import { EducationPhase } from "./EducationPhase";
import { ExamData } from "./ExamData";

export class GJournal {
    public Id: number;

    public GraduateId: number;

    public RationalInfoId: number;
    public RationalInfo: RationalInfo;

    public ThesisPlanId: number;
    public ThesisPlan: ThesisPlan;

    public WorkPlans: WorkPlan[];
    public EducationYears: EducationPhase[];
    public ExamsData: ExamData[];
}
