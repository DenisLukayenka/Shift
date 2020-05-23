import { Injectable } from "@angular/core";
import { FormBuilder, FormGroup, Validators, FormArray } from "@angular/forms";
import { UJournal } from "src/app/infrastracture/entities/ujournal/UJournal";
import * as _ from 'lodash';
import { isPropertyDefined } from "src/app/infrastracture/utilities/isPropertyDefined";

@Injectable()
export class UJHelperService {
    private options: FormGroup;

    constructor(private fb: FormBuilder) {}

    public generateFormOptions(journal: UJournal): FormGroup {
        this.options = this.initJournal();

        if(journal && journal.ReportResults) {
            journal.ReportResults.forEach(r => this.addReportResults());
            if(journal.ReportResults.length === 0) {
                this.addReportResults();
            }
        }
        if(journal && journal.PreparationInfo && journal.PreparationInfo.ResearchWorks) {
            journal.PreparationInfo.ResearchWorks.forEach(w => this.addResearchWork());
            if(journal.PreparationInfo.ResearchWorks.length === 0) {
                this.addResearchWork();
            }
        }

        const truthyJournal = _.pickBy(journal, isPropertyDefined);
        this.options.patchValue(truthyJournal);

        return this.options;
    }

    public initJournal(): FormGroup {
        return this.fb.group({
            Id: [null],
            UndergraduateId: [null],
            PreparationInfoId: [null],
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
            ThesisCertificationId: [null],
            ThesisCertification: this.fb.group({
                ThesisCertificationId: [null],
                IsApproved: [false],
                Mark: [null, [
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
                Number: [null]
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