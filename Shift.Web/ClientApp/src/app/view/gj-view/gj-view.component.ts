import { Component, OnInit } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { Store, select } from "@ngrx/store";
import { StudentState, selectGJournal } from "src/app/core/store/student/student.state";
import * as _ from 'lodash';
import { GJHelperService } from "./gj-helper.service";
import { Observable } from "rxjs";
import { selectViewLoading } from "src/app/core/store/app/app.state";
import { StorageService } from "src/app/services/storage/storage.service";
import { UserIdKey } from "src/app/services/storage/StorageKeys";
import { ExecuteLoadGJournal, SaveGJournal } from "src/app/core/store/student/student.actions";

@Component({
    selector: 'pac-gj-view',
    styleUrls: ['./gj-view.component.scss'],
    templateUrl: './gj-view.component.html',
    providers: [GJHelperService]
})
export class GraduateJournalComponent implements OnInit {
    public isViewLoading$: Observable<boolean>;
    public journalOptions: FormGroup;

    constructor(
        private studentState: Store<StudentState>,
        public gjHelper: GJHelperService,
        private storage: StorageService,
    ){
        this.studentState.pipe(select(selectGJournal)).subscribe(result => {
            if(result) {
                this.journalOptions = this.gjHelper.generateFormGroup(result);
                this.gjHelper.addWorkPlan();
            }
        });
        this.isViewLoading$ = this.studentState.pipe(select(selectViewLoading));
    }

    public ngOnInit() {
        let userId = +this.storage.getValue(UserIdKey);
        this.studentState.dispatch(new ExecuteLoadGJournal({ userId: userId }));
    }

    public submitJournal() {
        let formJournal = _.cloneDeep(this.journalOptions.value);
        this.studentState.dispatch(new SaveGJournal({ journal: formJournal }));
        console.log(formJournal);
    }
}