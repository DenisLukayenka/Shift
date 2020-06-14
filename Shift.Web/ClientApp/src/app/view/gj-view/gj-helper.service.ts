import { Injectable } from "@angular/core";
import { FormBuilder, FormGroup, FormArray } from "@angular/forms";
import { GJournal } from "src/app/infrastracture/entities/gjournal/GJournal";
import * as _ from 'lodash';
import { generateForm } from "src/app/infrastracture/utilities/generateForm";
import { ViewMode } from "src/app/infrastracture/entities/ViewMode";

@Injectable()
export class GJHelperService {
    private options: FormGroup;

    constructor(private fb: FormBuilder) {}

    public generateFormGroup(journal: GJournal, viewMode: ViewMode = ViewMode.Student) {
        let formGenerated = generateForm(journal, null, viewMode);
        this.options = formGenerated as FormGroup;
        console.log(this.options);

        return this.options;
    }

    public initWorkStage(): FormGroup {
        return this.fb.group({
            Id: [null],
            JobInfo: [null],
            StartDate: [null],
            FinishDate: [null],
            SubmitDate: [null],
            ApproveDate: [null],
            IsSubmitted: [false],
            IsApproved: [false],
            Note: [null],
            WorkPlanId: [null],
        });
    }
    public initWorkPlan(): FormGroup {
        return this.fb.group({
            WorkPlanId: [null],
            IsSubmitted: [false],
            SubmitDate: [null],

            Adviser: [null],
            AdviserApproveDate: [null],
            IsAdviserApproved: [false],

            TrainingHead: [null],
            TrainingHeadApproveDate: [null],
            IsTrainingHeadApproved: [false],

            FinalCertification: [null],
            CouncilNumber: [null],
            GraduateJournalId: [null],
            WorkStages: this.fb.array([])
        })
    }
    public initEducationPhase(): FormGroup {
        return this.fb.group({
            Id: [null],
            TripsInternships: [null],
            SubWorks: [null],
            Publications: [null],
            ScienceParticipations: [null],
            SubResearchResults: [null],
            JournalId: [null],

            Adviser: [null],
            AdviserApproveDate: [null],
            IsAdviserApproved: [false],

            SubmitDate: [null],
            IsSubmitted: [false],

            CalendarStages: this.fb.array([]),
            ScienceActivities: this.fb.array([]),
            Attestations: this.fb.array([]),
        })
    }
    public initCalendarStage(): FormGroup {
        return this.fb.group({
            Id: [null],
            StageName: [null],
            StartDate: [null],
            FinishDate: [null],
            WaitResult: [null],
            OutcomeResult: [null],
            EducationPhaseId: [null],
        });
    }
    public initScienceActivity(): FormGroup {
        return this.fb.group({
            Id: [null],
            StartDate: [null],
            FinishDate: [null],
            Title: [null],
            Address: [null],
            PlanResult: [null],
            EducationPhaseId: [null],
        });
    }
    public initAttestation(): FormGroup {
        return this.fb.group({
            Id: [null],
            AttestationResult: [null],

            Adviser: [null],
            AdviserApproveDate: [null],
            IsAdviserApproved: [false],

            DepartmentHead: [null],
            DepartmentHeadApproveDate: [null],
            IsDepartmentHeadApproved: [false],

            TrainingHead: [null],
            TrainingHeadApproveDate: [null],
            IsTrainingHeadApproved: [false],

            ProtocolId: [null],
            EducationPhaseId: [null],
        });
    }
    public initExamData(): FormGroup {
        return this.fb.group({
            Id: [null],
            Mark: [null],
            Date: [null],
            DisciplineId: [null],
            Discipline: this.initDiscipline(),
            GraduateJournalId: [null],
        });
    }
    public initDiscipline(): FormGroup {
        return this.fb.group({
            Id: [null],
            FullName: [null],
            Abbreviation: [null],
        });
    }

    public addExamData() {
        const control = this.options.get('ExamsData') as FormArray;
        control.push(this.initExamData());
    }

    public addWorkStage(planIndex: number) {
        const control = (this.options.get('WorkPlans') as FormArray).controls[planIndex].get('WorkStages') as FormArray;
        control.push(this.initWorkStage());
    }

    public addCalendarStage(phaseIndex: number) {
        const control = (this.options.get('EducationYears') as FormArray).controls[phaseIndex].get('CalendarStages') as FormArray;
        control.push(this.initCalendarStage());
    }

    public addScienceActivity(phaseIndex: number) {
        const control = (this.options.get('EducationYears') as FormArray).controls[phaseIndex].get('ScienceActivities') as FormArray;
        control.push(this.initScienceActivity());
    }

    public addAttestation(phaseIndex: number) {
        const control = (this.options.get('EducationYears') as FormArray).controls[phaseIndex].get('Attestations') as FormArray;
        control.push(this.initAttestation());
    }

    get WorkPlansFormControls() {
        const control = this.options.get('WorkPlans') as FormArray;
        return control;
    }

    get EducationYearsFormControls() {
        const control = this.options.get('EducationYears') as FormArray;
        return control;
    }

    get WorkStagesFormControls() {
        const control = this.options.get('WorkPlans').get('WorkStages') as FormArray;
        return control;
    }

    get ScienceActivitiesFormControls() {
        const control = this.options.get('EducationYears').get('ScienceActivities') as FormArray;
        return control;
    }

    get AttestationsFormControls() {
        const control = this.options.get('EducationYears').get('Attestations') as FormArray;
        return control;
    }

    get RationalInfoControl() {
        const control = this.options.get('RationalInfo') as FormGroup;
        return control;
    }

    get ThesisPlanControl() {
        const control = this.options.get('ThesisPlan') as FormGroup;
        return control;
    }

    get ExamsData() {
        const control = this.options.get('ExamsData') as FormArray;
        return control;
    }

    public deleteWorkStage(workPlanIndex: number, workStageIndex: number) {
        const control = (this.options.get('WorkPlans') as FormArray).controls[workPlanIndex].get('WorkStages') as FormArray;
        control.removeAt(workStageIndex);
    }

    public deleteCalendarStage(educationPhaseIndex: number, calendarStageIndex: number) {
        const stages = (this.options.get('EducationYears') as FormArray).controls[educationPhaseIndex].get('CalendarStages') as FormArray;
        stages.removeAt(calendarStageIndex);
    }

    public deleteScienceActivity(educationPhaseIndex: number, activityIndex: number) {
        const control = (this.options.get('EducationYears') as FormArray).controls[educationPhaseIndex].get('ScienceActivities') as FormArray;
        control.removeAt(activityIndex);
    }

    public deleteExam(index: number) {
        const control = this.options.get('ExamsData') as FormArray;
        control.removeAt(index);
    }
}