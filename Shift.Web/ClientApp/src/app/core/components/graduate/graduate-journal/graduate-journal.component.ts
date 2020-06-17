import { Component, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { GJournal } from "src/app/infrastracture/entities/gjournal/GJournal";
import { ViewMode } from "src/app/infrastracture/entities/ViewMode";
import { Store, select } from "@ngrx/store";
import { StudentState, selectGJournal } from "src/app/core/store/student/student.state";
import { StorageService } from "src/app/services/storage/storage.service";
import { selectViewLoading } from "src/app/core/store/app/app.state";
import { UserIdKey } from "src/app/services/storage/StorageKeys";
import { ExecuteLoadGJournal, SaveGJournal, DownloadGJournal } from "src/app/core/store/student/student.actions";
import { ViewStartLoading } from "src/app/core/store/app/app.actions";

@Component({
    selector: 'pac-graduate-journal',
    templateUrl: './graduate-journal.component.html',
})
export class GraduateJournalComponent implements OnInit {
    public journal$: Observable<GJournal>;
    public isViewLoading$: Observable<boolean>;
    public ViewModes = ViewMode;

    constructor(private studentState: Store<StudentState>, private storage: StorageService) {
        this.isViewLoading$ = this.studentState.pipe(select(selectViewLoading));
        this.journal$ = this.studentState.pipe(select(selectGJournal));
    }

    public ngOnInit() {
        let userId = +this.storage.getValue(UserIdKey);
        this.studentState.dispatch(new ExecuteLoadGJournal({ userId: userId }));
    }

    public updateJornal(journal: GJournal) {
        this.studentState.dispatch(new ViewStartLoading());
        this.studentState.dispatch(new SaveGJournal({ journal: journal }));
    }

    public downloadJournal() {
        let userId = +this.storage.getValue(UserIdKey);

        this.studentState.dispatch(new ViewStartLoading());
        this.studentState.dispatch(new DownloadGJournal({ userId: userId }));
        console.log("download");
    }
}