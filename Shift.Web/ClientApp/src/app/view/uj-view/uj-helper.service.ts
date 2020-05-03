import { Injectable } from "@angular/core";
import { FormBuilder, FormGroup, Validators, FormArray } from "@angular/forms";
import { UJournal } from "src/app/infrastracture/entities/ujournal/UJournal";

@Injectable()
export class UJHelperService {
    private options: FormGroup;

    constructor(private fb: FormBuilder) {}

    public generateFormOptions(journal: UJournal): FormGroup {
        this.options = this.initJournal();

        journal.ReportResults.forEach(r => this.addReportResults());
        journal.PreparationInfo.ResearchWorks.forEach(w => this.addResearchWork());

        this.options.patchValue(journal);

        return this.options;
    }

    public initJournal(): FormGroup {
        return this.fb.group({
            PreparationInfo: this.fb.group({
                PreparationInfoId: [''],
                Topic: [''],
                Relevance: [''],
                Objectives: [''],
                ResearchProcedure: [''],
                Additions: [''],
                PreparationSubmittedDate: [{ value: null, disabled: true }],
                PreparationApprovedDate: [{ value: null, disabled: true }],
                IsPreparationSubmitted: [false],
                IsPreparationApproved: [false],
                IsResearchSubmitted: [false],
                IsResearchApproved: [false],
                ResearchWorks: this.fb.array([]),
            }),
            ReportResults: this.fb.array([]),
            ThesisCertification: this.fb.group({
                ThesisCertificationId: [''],
                IsApproved: [false],
                Mark: ['', [
                    Validators.required,
                    Validators.pattern("^[1-9]|10")
                ]],
                ApprovedDate: [null],
                DepartmentHead: [null],
            })
        });
    }
    public initReportResults(): FormGroup {
        return this.fb.group({
            Date: [null],
            Result: ['', Validators.required],
            DepartmentHead: [''],
            Protocol: this.fb.group({
                Date: [null],
                Number: ['']
            }),
        });
    }
    public initResearchWork(): FormGroup {
        return this.fb.group({
            JobType: ['', Validators.required],
            PresentationType: ['', Validators.required],
            StartDate: [null],
            FinishDate: [null],
            PreparationInfoId: [''],
        });
    }

    public addResearchWork() {
        const control = this.options.get('PreparationInfo').get('ResearchWorks') as FormArray;
        control.push(this.initResearchWork());
    }

    public addReportResults() {
        const control = this.options.get('ReportResults') as FormArray;
        control.push(this.initReportResults());
    }

    public deleteResearchWork(index: number) {
        const control = this.options.get('PreparationInfo').get('ResearchWorks') as FormArray;
        control.removeAt(index);
    }

    public deleteReportResult(index: number) {
        const control = this.options.get('ReportResults') as FormArray;
        control.removeAt(index);
    }

    get getRWFormControls() {
        const control = this.options.get('PreparationInfo').get('ResearchWorks') as FormArray;
        return control;
    }

    get getRRFormControls() {
        const control = this.options.get('ReportResults') as FormArray;
        return control;
    }
}