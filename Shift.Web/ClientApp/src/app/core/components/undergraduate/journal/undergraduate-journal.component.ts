import { Component, OnInit } from "@angular/core";
import { UJournal } from "src/app/infrastracture/entities/ujournal/UJournal";
import { Store, select } from "@ngrx/store";
import { StudentState, selectUJournal } from "src/app/core/store/student/student.state";
import { SaveUJournal, ExecuteLoadUJournal, DownloadUJournal } from "src/app/core/store/student/student.actions";
import { Observable } from "rxjs";
import { selectViewLoading } from "src/app/core/store/app/app.state";
import { StorageService } from "src/app/services/storage/storage.service";
import { UserIdKey } from "src/app/services/storage/StorageKeys";
import { ViewMode } from "src/app/infrastracture/entities/ViewMode";
import { ViewStartLoading } from "src/app/core/store/app/app.actions";

@Component({
    selector: 'pac-undergraduate-journal',
    templateUrl: './undergraduate-journal.component.html',
})
export class UndergraduateJournalComponent implements OnInit {
    public journal$: Observable<UJournal>;
    public isViewLoading$: Observable<boolean>;
    public ViewModes = ViewMode;

    constructor(private studentState: Store<StudentState>, private storage: StorageService) {
        this.isViewLoading$ = this.studentState.pipe(select(selectViewLoading));
        this.journal$ = this.studentState.pipe(select(selectUJournal));
    }

    public ngOnInit() {
        let userId = +this.storage.getValue(UserIdKey);
        this.studentState.dispatch(new ExecuteLoadUJournal({ userId: userId }));
    }

    public updateUJornal(journal: UJournal) {
        this.studentState.dispatch(new ViewStartLoading());
        this.studentState.dispatch(new SaveUJournal({ journal: journal }));
    }

    public downloadUJournal() {
        let userId = +this.storage.getValue(UserIdKey);

        this.studentState.dispatch(new ViewStartLoading());
        this.studentState.dispatch(new DownloadUJournal({ userId: userId }));
    }
}