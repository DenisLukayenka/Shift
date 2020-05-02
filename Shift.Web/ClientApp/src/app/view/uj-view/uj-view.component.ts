import { Component, Input, OnChanges, SimpleChanges, ChangeDetectionStrategy } from "@angular/core";
import { StudentState } from "src/app/core/store/student/student.state";
import { Store } from "@ngrx/store";
import { UJournal } from "src/app/infrastracture/entities/ujournal/UJournal";
import { SaveUJournal } from "src/app/core/store/student/student.actions";
import { FormGroup, FormArray, FormControl } from "@angular/forms";
import * as _ from 'lodash';
import { UJHelperService } from "./uj-helper.service";

@Component({
    selector: 'pac-uj-view',
    styleUrls: ['./uj-view.component.scss'],
    templateUrl: './uj-view.component.html',
    providers: [UJHelperService],
})
export class UndergraduateJournalComponent implements OnChanges {
    @Input() public journal: UJournal;

    public journalOptions: FormGroup;
    
    constructor(
        private studentState: Store<StudentState>,
        public ujHelper: UJHelperService,
    ) {}

    ngOnChanges (changes: SimpleChanges ): void {
        if(changes.journal.currentValue) {
            this.journalOptions = this.ujHelper.generateFormOptions(changes.journal.currentValue);

            this.addReport();
            this.addResearchWork();
        }
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
        return this.ujHelper.initResearchWork();
    }

    public initialeReportResult(): FormGroup {
        return this.ujHelper.initReportResults();
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