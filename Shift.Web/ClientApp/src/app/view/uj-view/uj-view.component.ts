import { Component, OnInit, NgZone, ViewChild } from "@angular/core";
import { StudentState, selectUJournal } from "src/app/core/store/student/student.state";
import { Store, select } from "@ngrx/store";
import { UJournal } from "src/app/infrastracture/entities/ujournal/UJournal";
import { StorageService } from "src/app/services/storage/storage.service";
import { UserIdKey } from "src/app/services/storage/StorageKeys";
import { LoadUJournal, SaveUJournal } from "src/app/core/store/student/student.actions";
import { FormBuilder, FormGroup, FormArray, Validators, FormControl } from "@angular/forms";
import * as _ from 'lodash';

@Component({
    selector: 'pac-uj-view',
    styleUrls: ['./uj-view.component.scss'],
    templateUrl: './uj-view.component.html',
})
export class UndergraduateJournalComponent implements OnInit {
    public journal: UJournal;
    public journalOptions: FormGroup;
    
    constructor(
        private studentState: Store<StudentState>, 
        private storage: StorageService,
        private fb: FormBuilder,
    ) {
        this.studentState.pipe(select(selectUJournal)).subscribe(j => {
            if(!!j && !!this.journalOptions) {
                this.journal = j;
                this.journalOptions.patchValue(this.journal);
                this.addResearchWork();
                this.addReport();
            }
        });
    }

    ngOnInit() {
        let userId = +this.storage.getValue(UserIdKey);
        this.studentState.dispatch(new LoadUJournal({ userId: userId }));
        this.initializeForm();
    }

    public initializeForm() {
        this.journalOptions = this.fb.group({
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

    public submitJournal() {
        let formJournal = _.cloneDeep(this.journalOptions.value);
        let researchWorks = _.filter(formJournal.PreparationInfo.ResearchWorks, work => !!work.JobType && !!work.PresentationType);
        let mark = +formJournal.ThesisCertification.Mark;
        let reportResults = _.filter(formJournal.ReportResults, result => !!result.Result);

        formJournal.PreparationInfo.ResearchWorks = researchWorks;
        formJournal.ReportResults = reportResults;
        formJournal.ThesisCertification.Mark = mark;

        this.studentState.dispatch(new SaveUJournal({ journal: formJournal }));
    }

    public submitPreparation() {
        const control = this.journalOptions.get('PreparationInfo').get('PreparationSubmittedDate') as FormControl;
        control.setValue(new Date());
    }

    public addResearchWork() {
        const control = this.journalOptions.get('PreparationInfo').get('ResearchWorks') as FormArray;
        control.push(this.initialeResearchWork())
    }

    public deleteResearchWork(index: number) {
        const control = this.journalOptions.get('PreparationInfo').get('ResearchWorks') as FormArray;
        control.removeAt(index);
    }

    public addReport() {
        const control = this.journalOptions.get('ReportResults') as FormArray;
        control.push(this.initialeReportResult());
    }

    public deleteReport(index: number) {
        const control = this.journalOptions.get('ReportResults') as FormArray;
        control.removeAt(index);
    }

    public initialeResearchWork(): FormGroup {
        return this.fb.group({
            JobType: ['', Validators.required],
            PresentationType: ['', Validators.required],
            StartDate: [null],
            FinishDate: [null],
            PreparationInfoId: [this.journal.PreparationInfo.PreparationInfoId],
        });
    }

    public initialeReportResult(): FormGroup {
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

    get getRWFormControls() {
        const control = this.journalOptions.get('PreparationInfo').get('ResearchWorks') as FormArray;
        return control;
    }

    get getRRFormControls() {
        const control = this.journalOptions.get('ReportResults') as FormArray;
        return control;
    }
}