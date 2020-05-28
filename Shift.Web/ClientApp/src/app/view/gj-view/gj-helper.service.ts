import { Injectable } from "@angular/core";
import { FormBuilder, FormGroup, FormArray } from "@angular/forms";
import { GJournal } from "src/app/infrastracture/entities/gjournal/GJournal";
import * as _ from 'lodash';
import { isPropertyDefined } from "src/app/infrastracture/utilities/isPropertyDefined";

@Injectable()
export class GJHelperService {
    private options: FormGroup;

    constructor(private fb: FormBuilder) {}

    public generateFormGroup(journal: GJournal) {
        this.options = this.initJournal();

        if (journal && journal.EducationYears) {
            journal.EducationYears.forEach((phase, i) => {
                this.addEducationYear();
                if(phase.CalendarStages){
                    phase.CalendarStages.forEach(s => this.addCalendarStage(i));
                }
                if(phase.ScienceActivities){
                    phase.ScienceActivities.forEach(s => this.addScienceActivity(i));
                }
                if(phase.Attestations){
                    phase.Attestations.forEach(s => this.addAttestation(i));
                }
            });
        }
        this.addScienceActivity(0);
        this.addCalendarStage(0);
        this.addWorkPlan();
        this.addWorkStage(0);
        
        if(journal && journal.WorkPlans){
            if(journal.WorkPlans.length > 0) {
                this.addWorkStage(0);
            }
            
            journal.WorkPlans.forEach((plan, i) => {
                this.addWorkPlan();
                if(plan.WorkStages) {
                    plan.WorkStages.forEach(() => this.addWorkStage(i));
                }

                if(this.WorkStagesFormControls.length === 0) {
                    this.addWorkStage(i);
                }
            });
        }
        if(journal && journal.ExamInfo) {
            journal.ExamInfo.forEach(info => {
                this.addExamInfo();
            });
        }
        if(this.ExamInfo.length === 0) {
            this.addExamInfo();
        }

        const truthyRationalInfo = _.pickBy(journal.RationalInfo, isPropertyDefined);
        const truthyJournal = _.pickBy(journal, isPropertyDefined) as GJournal;
        const updatedTruthyJournal = _.assign(truthyJournal, { RationalInfo: truthyRationalInfo });

        this.options.patchValue(updatedTruthyJournal);

        return this.options;
    }

    public initJournal(): FormGroup {
        return this.fb.group({
            Id: [null],
            RationalInfo: this.fb.group({
                RationalInfoId: [null],
                StudyPurpose: [null],
                StudyObject: [null],
                StudySubject: [null],
                Justification: [null],

                ThesisPublications: [null],
                ResearchParticipation: [null],
                DissertationTopic: [null],

                DepartmentHead: [null],
                DepartmentHeadApproveDate: [null],
                IsDepartmentHeadApproved: [false],

                TrainingHead: [null],
                TrainingHeadApproveDate: [null],
                IsTrainingHeadApproved: [false],

                Adviser: [null],
                AdviserApproveDate: [{ value: null, disabled: false }],
                IsAdviserApproved: [false],

                ProtocolId: [null],
                Protocol: this.initProtocol(),

                GraduateJournalId: [null],
            }),
            ThesisPlan: this.fb.group({
                ThesisPlanId: [null],
                Info: [null],
                Adviser: [null],
                AdviserApproveDate: [null],
                SubmitDate: [null],
                IsSubmitted: [false],
                IsApproved: [false],
                GraduateJournalId: [null],
            }),
            WorkPlans: this.fb.array([]),
            EducationYears: this.fb.array([]),
            ExamInfo: this.fb.array([]),
        });
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
    public initProtocol(): FormGroup {
        return this.fb.group({
            ProtocolId: [null],
            Date: [null],
            Number: [null],
        });
    }
    public initExamInfo(): FormGroup {
        return this.fb.group({
            Id: [null],
            Mark: [null],
            Date: [null],
            DisciplineId: [null],
            GraduateJournalId: [null],
        });
    }


    public addEducationYear(){
        const control = this.options.get('EducationYears') as FormArray;
        control.push(this.initEducationPhase());
    }

    public addWorkPlan() {
        const control = this.options.get('WorkPlans') as FormArray;
        control.push(this.initWorkPlan());
    }

    public addExamInfo() {
        const control = this.options.get('ExamInfo') as FormArray;
        control.push(this.initExamInfo());
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

    get ExamInfo() {
        const control = this.options.get('ExamInfo') as FormArray;
        return control;
    }

    public deleteWorkStage(workPlanIndex: number, workStageIndex: number) {
        const control = this.options.get('WorkPlans')[workPlanIndex] as FormArray;
        control.removeAt(workStageIndex);
    }

    public deleteCalendarStage(EducationPhaseIndex: number, calendarStageIndex: number) {
        const control = this.options.get('EducationYears')[EducationPhaseIndex] as FormArray;
        control.removeAt(calendarStageIndex);
    }

    public deleteScienceActivity(EducationPhaseIndex: number, activityIndex: number) {
        const control = this.options.get('EducationYears')[EducationPhaseIndex] as FormArray;
        control.removeAt(activityIndex);
    }
}