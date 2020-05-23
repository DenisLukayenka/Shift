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
        if(journal && journal.WorkPlans){
            journal.WorkPlans.forEach((plan, i) => {
                this.addWorkPlan();
                if(plan.WorkStages) {
                    plan.WorkStages.forEach(() => this.addWorkStage(i));
                }
            });
        }
        const truthyJournal = _.pickBy(journal, isPropertyDefined);
        this.options.patchValue(truthyJournal);

        return this.options;
    }

    public initJournal(): FormGroup {
        return this.fb.group({
            RationalInfo: this.fb.group({
                RationalInfoId: [''],
                StudyPurpose: [''],
                StudyObject: [''],
                StudySubject: [''],
                Justification: [''],

                ThesisPublications: [''],
                ResearchParticipation: [''],
                DissertationTopic: [''],

                DepartmentHead: [''],
                DepartmentHeadApproveDate: [null],
                IsDepartmentHeadApproved: [false],

                TrainingHead: [''],
                TrainingHeadApproveDate: [null],
                IsTrainingHeadApproved: [false],

                Adviser: [''],
                AdviserApproveDate: [null],
                IsAdviserApproved: [false],

                Protocol: this.fb.group({
                    Date: [null],
                    Number: [''],
                }),

                GraduateJournalId: [''],
            }),
            ThesisPlan: this.fb.group({
                ThesisPlanId: [''],
                Info: [''],
                Adviser: [''],
                AdviserApproveDate: [null],
                SubmitDate: [null],
                IsSubmitted: [false],
                IsApproved: [false],
                GraduateJournalId: [''],
            }),
            WorkPlans: this.fb.array([]),
            EducationYears: this.fb.array([]),
        });
    }
    public initWorkStage(): FormGroup {
        return this.fb.group({
            Id: [''],
            JobInfo: [''],
            StartDate: [null],
            FinishDate: [null],
            SubmitDate: [null],
            ApproveDate: [null],
            IsSubmitted: [false],
            IsApproved: [false],
            Note: [''],
            WorkPlanId: [''],
        });
    }
    public initWorkPlan(): FormGroup {
        return this.fb.group({
            WorkPlanId: [''],
            IsSubmitted: [false],
            SubmitDate: [null],

            Adviser: [''],
            AdviserApproveDate: [null],
            IsAdviserApproved: [false],

            TrainingHead: [''],
            TrainingHeadApproveDate: [null],
            IsTrainingHeadApproved: [false],

            FinalCertification: [''],
            CouncilNumber: [''],
            GraduateJournalId: [''],
            WorkStages: this.fb.array([])
        })
    }
    public initEducationPhase(): FormGroup {
        return this.fb.group({
            Id: [''],
            TripsInternships: [''],
            SubWorks: [''],
            Publications: [''],
            ScienceParticipations: [''],
            SubResearchResults: [''],
            JournalId: [''],

            Adviser: [''],
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
            Id: [''],
            StageName: [''],
            StartDate: [null],
            FinishDate: [null],
            WaitResult: [''],
            OutcomeResult: [''],
            EducationPhaseId: [''],
        });
    }
    public initScienceActivity(): FormGroup {
        return this.fb.group({
            Id: [''],
            StartDate: [null],
            FinishDate: [null],
            Title: [''],
            Address: [''],
            PlanResult: [''],
            EducationPhaseId: [''],
        });
    }
    public initAttestation(): FormGroup {
        return this.fb.group({
            Id: [''],
            AttestationResult: [''],

            Adviser: [''],
            AdviserApproveDate: [null],
            IsAdviserApproved: [false],

            DepartmentHead: [''],
            DepartmentHeadApproveDate: [null],
            IsDepartmentHeadApproved: [false],

            TrainingHead: [''],
            TrainingHeadApproveDate: [null],
            IsTrainingHeadApproved: [false],

            Protocol: this.initProtocol(),
            EducationPhaseId: [''],
        });
    }
    public initProtocol(): FormGroup {
        return this.fb.group({
            Date: [null],
            Number: [''],
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

    public addWorkStage(planIndex: number) {
        const control = this.options.get('WorkPlans')[planIndex].get('WorkStages') as FormArray;
        control.push(this.initWorkStage());
    }

    public addCalendarStage(phaseIndex: number) {
        const control = this.options.get('EducationYears')[phaseIndex].get('CalendarStages') as FormArray;
        control.push(this.initCalendarStage());
    }

    public addScienceActivity(phaseIndex: number) {
        const control = this.options.get('EducationYears')[phaseIndex].get('ScienceActivities') as FormArray;
        control.push(this.initScienceActivity());
    }

    public addAttestation(phaseIndex: number) {
        const control = this.options.get('EducationYears')[phaseIndex].get('Attestations') as FormArray;
        control.push(this.initAttestation());
    }

    get getWorkPlansFormControls() {
        const control = this.options.get('WorkPlans') as FormArray;
        return control;
    }

    get getEducationYearsFormControls() {
        const control = this.options.get('EducationYears') as FormArray;
        return control;
    }

    get getWorkStagesFormControls() {
        const control = this.options.get('WorkPlans').get('WorkStages') as FormArray;
        return control;
    }

    get getScienceActivitiesFormControls() {
        const control = this.options.get('EducationYears').get('ScienceActivities') as FormArray;
        return control;
    }

    get getAttestationsFormControls() {
        const control = this.options.get('EducationYears').get('Attestations') as FormArray;
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