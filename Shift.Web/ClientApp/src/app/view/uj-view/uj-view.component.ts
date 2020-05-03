import { Component, OnInit } from "@angular/core";
import { StudentState, selectUJournal } from "src/app/core/store/student/student.state";
import { Store, select } from "@ngrx/store";
import { SaveUJournal, ExecuteLoadUJournal } from "src/app/core/store/student/student.actions";
import { FormGroup, FormControl } from "@angular/forms";
import * as _ from 'lodash';
import { UJHelperService } from "./uj-helper.service";
import { StorageService } from "src/app/services/storage/storage.service";
import { UserIdKey } from "src/app/services/storage/StorageKeys";
import { Observable } from "rxjs";
import { selectViewLoading } from "src/app/core/store/app/app.state";

@Component({
    selector: 'pac-uj-view',
    styleUrls: ['./uj-view.component.scss'],
    templateUrl: './uj-view.component.html',
    providers: [UJHelperService],
})
export class UndergraduateJournalComponent implements OnInit {
    public journalOptions: FormGroup;
    public isViewLoading$: Observable<boolean>;
    
    constructor(
        private studentState: Store<StudentState>,
        public ujHelper: UJHelperService,
        private storage: StorageService,
    ) {
        this.isViewLoading$ = this.studentState.pipe(select(selectViewLoading));
        this.studentState.pipe(select(selectUJournal)).subscribe(result => {
            if(result) {
                this.journalOptions = this.ujHelper.generateFormOptions(result);
                this.ujHelper.addResearchWork();
                this.ujHelper.addReportResults();
            }
        });
    }

    public ngOnInit() {
        let userId = +this.storage.getValue(UserIdKey);
        this.studentState.dispatch(new ExecuteLoadUJournal({ userId: userId }));
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
}