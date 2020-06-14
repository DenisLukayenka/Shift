import { Injectable } from "@angular/core";
import { FormBuilder, FormGroup, Validators, FormArray, FormControl } from "@angular/forms";
import { UJournal } from "src/app/infrastracture/entities/ujournal/UJournal";
import * as _ from 'lodash';
import { ViewMode } from "src/app/infrastracture/entities/ViewMode";
import { generateForm } from "src/app/infrastracture/utilities/generateForm";

@Injectable()
export class UJHelperService {
    private options: FormGroup;
    private viewMode: ViewMode;

    constructor(private fb: FormBuilder) {}

    public generateFormOptions(journal: UJournal, viewMode: ViewMode = ViewMode.Student): FormGroup {
        this.viewMode = viewMode;
        
        let formGenerated = generateForm(journal, null, viewMode);
        this.options = formGenerated as FormGroup;
        console.log(this.options);

        return this.options;
    }

    public initReportResults(): FormGroup {
        return this.fb.group({
            Id: [null],
            Result: ['', Validators.required],
            UndergraduateJournalId: [null],
            ProtocolId: [null],
            Protocol: this.fb.group({
                ProtocolId: [null],
                Date: [null],
                Number: [null]
            }),
        });
    }
    public initResearchWork(): FormGroup {
        return this.fb.group({
            Id: [null],
            JobType: [{ value: null, disabled: !this.IsStudentMode }, Validators.required],
            PresentationType: [{ value: null, disabled: !this.IsStudentMode }, Validators.required],
            StartDate: [{ value: null, disabled: !this.IsStudentMode }],
            FinishDate: [{ value: null, disabled: !this.IsStudentMode }],
            PreparationInfoId: [this.PreparationInfoId],
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

    get PreparationInfoId() {
        const control = this.options.get('PreparationInfo') as FormGroup;
        return control.get('PreparationInfoId').value;
    }

    get PreparationSubmittedDateControl() {
        const control = this.options.get('PreparationInfo').get('PreparationSubmittedDate') as FormControl;
        return control;
    }
    get IsPreparationSubmittedControl() {
        const control = this.options.get('PreparationInfo').get('IsPreparationSubmitted') as FormControl;
        return control;
    }

    get PreparationApprovedDateControl() {
        const control = this.options.get('PreparationInfo').get('PreparationApprovedDate') as FormControl;
        return control;
    }
    get IsPreparationApprovedControl() {
        const control = this.options.get('PreparationInfo').get('IsPreparationApproved') as FormControl;
        return control;
    }

    get ReseachSubmittedDateControl() {
        const control = this.options.get('PreparationInfo').get('ReseachSubmittedDate') as FormControl;
        return control;
    }
    get IsResearchSubmittedControl() {
        const control = this.options.get('PreparationInfo').get('IsResearchSubmitted') as FormControl;
        return control;
    }

    get ReseachApprovedDateDateControl() {
        const control = this.options.get('PreparationInfo').get('ReseachApprovedDate') as FormControl;
        return control;
    }
    get IsResearchApprovedControl() {
        const control = this.options.get('PreparationInfo').get('IsResearchApproved') as FormControl;
        return control;
    }

    get ThesisCertificationControl() {
        const control = this.options.get('ThesisCertification') as FormGroup;
        return control;
    }

    private get IsStudentMode(): boolean {
        return this.viewMode === ViewMode.Student;
    }
}