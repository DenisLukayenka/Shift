import { Injectable } from "@angular/core";
import { FormBuilder, FormGroup, FormArray } from "@angular/forms";
import { GJournal } from "src/app/infrastracture/entities/gjournal/GJournal";
import * as _ from 'lodash';

@Injectable()
export class GJHelperService {
    private options: FormGroup;

    constructor(private fb: FormBuilder) {}

    public generateFormGroup(journal: GJournal) {
        this.options = this.initJournal();

        journal.EducationYears.forEach(phase => {
            this.addEducationYear();
            phase.CalendarStages.forEach(s => this.addCalendarStage());
            phase.ScienceActivities.forEach(s => this.addScienceActivity());
            phase.Attestations.forEach(s => this.addAttestation());
        });

        journal.WorkPlans.forEach(plan => {
            this.addWorkStage();
            plan.WorkStages.forEach(() => this.addWorkPlan());
        })

        this.options.patchValue(journal);

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

    public addWorkStage() {
        const control = this.options.get('WorkPlans').get('WorkStages') as FormArray;
        control.push(this.initWorkStage());
    }

    public addCalendarStage() {
        const control = this.options.get('EducationYears').get('CalendarStages') as FormArray;
        control.push(this.initCalendarStage());
    }

    public addScienceActivity() {
        const control = this.options.get('EducationYears').get('ScienceActivities') as FormArray;
        control.push(this.initScienceActivity());
    }

    public addAttestation() {
        const control = this.options.get('EducationYears').get('Attestations') as FormArray;
        control.push(this.initAttestation());
    }
}