import { Injectable } from "@angular/core";
import { FormBuilder, FormGroup, Validators, FormArray, FormControl } from "@angular/forms";
import { UJournal } from "src/app/infrastracture/entities/ujournal/UJournal";
import * as _ from 'lodash';
import { isPropertyDefined } from "src/app/infrastracture/utilities/isPropertyDefined";
import { ViewMode } from "src/app/infrastracture/entities/ViewMode";

@Injectable()
export class UJHelperService {
    private options: FormGroup;
    private viewMode: ViewMode;

    constructor(private fb: FormBuilder) {}

    public generateFormOptions(journal: UJournal, viewMode: ViewMode = ViewMode.Student): FormGroup {
        this.viewMode = viewMode;

        this.options = this.initJournal();

        if(journal && journal.ReportResults) {
            journal.ReportResults.forEach(r => this.addReportResults());
        }
        if(journal && journal.PreparationInfo && journal.PreparationInfo.ResearchWorks) {
            journal.PreparationInfo.ResearchWorks.forEach(w => this.addResearchWork());
        }

        const truthyJournal = _.pickBy(journal, isPropertyDefined);
        this.options.patchValue(truthyJournal);

        if(journal.ReportResults.length === 0) {
            this.addReportResults();
        }
        if(journal.PreparationInfo.ResearchWorks.length === 0) {
            this.addResearchWork();
        }

        this.subscribeOnDatesChanges();

        return this.options;
    }

    public initJournal(): FormGroup {
        return this.fb.group({
            Id: [null],
            UndergraduateId: [null],
            PreparationInfoId: [null],
            PreparationInfo: this.fb.group({
                PreparationInfoId: [null],
                Topic: [{ value: null, disabled: !this.IsStudentMode }],
                Relevance: [{ value: null, disabled: !this.IsStudentMode }],
                Objectives: [{ value: null, disabled: !this.IsStudentMode }],
                ResearchProcedure: [{ value: null, disabled: !this.IsStudentMode }],
                Additions: [{ value: null, disabled: !this.IsStudentMode }],
                PreparationSubmittedDate: [{ value: null, disabled: !this.IsStudentMode }],
                PreparationApprovedDate: [{ value: null, disabled: this.IsStudentMode }],
                IsPreparationSubmitted: [false],
                IsPreparationApproved: [false],
                IsResearchSubmitted: [false],
                IsResearchApproved: [false],
                ReseachSubmittedDate: [{ value: null, disabled: !this.IsStudentMode }],
                ReseachApprovedDate: [{ value: null, disabled: this.IsStudentMode }],
                ResearchWorks: this.fb.array([]),
            }),
            ReportResults: this.fb.array([]),
            ThesisCertificationId: [null],
            ThesisCertification: this.fb.group({
                ThesisCertificationId: [null],
                IsApproved: [{ value: null, disabled: this.IsStudentMode }],
                Mark: [{ value: null, disabled: this.IsStudentMode }, [
                    Validators.required,
                ]],
                ApprovedDate: [{ value: null, disabled: this.IsStudentMode }],
            })
        });
    }
    public initReportResults(): FormGroup {
        return this.fb.group({
            Id: [null],
            Result: ['', Validators.required],
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

    public subscribeOnDatesChanges() {
        this.subscribeOnPreparationSubmit();
        this.subscribeOnPreparationApprove();
        this.subscribeOnResearchSubmit();
        this.subscribeOnReseacrhApprove();
    }

    public subscribeOnPreparationSubmit() {
        this.PreparationSubmittedDateControl.valueChanges.subscribe(date => {
            this.IsPreparationSubmittedControl.setValue(!!date);
        });
    }
    public subscribeOnPreparationApprove() {
        this.PreparationApprovedDateControl.valueChanges.subscribe(date => {
            this.IsPreparationApprovedControl.setValue(!!date);
        });
    }

    public subscribeOnResearchSubmit() {
        this.ReseachSubmittedDateControl.valueChanges.subscribe(date => {
            this.IsResearchSubmittedControl.setValue(!!date);
        });
    }
    public subscribeOnReseacrhApprove() {
        this.ReseachApprovedDateDateControl.valueChanges.subscribe(date => {
            this.IsResearchApprovedControl.setValue(!!date);
        });
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

    private get IsStudentMode(): boolean {
        return this.viewMode === ViewMode.Student;
    }
}