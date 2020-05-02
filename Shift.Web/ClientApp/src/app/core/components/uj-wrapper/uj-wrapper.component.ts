import { Component, OnInit } from "@angular/core";
import { UJournal } from "src/app/infrastracture/entities/ujournal/UJournal";
import { StorageService } from "src/app/services/storage/storage.service";
import { Store, select } from "@ngrx/store";
import { StudentState, selectUJournal } from "../../store/student/student.state";
import { UserIdKey } from "src/app/services/storage/StorageKeys";
import { ExecuteLoadUJournal } from "../../store/student/student.actions";
import { Observable } from "rxjs";
import { AppState, selectViewLoading } from "../../store/app/app.state";

@Component({
    selector: 'pac-uj-wrapper',
    templateUrl: './uj-wrapper.component.html'
})
export class UJWrapperComponent implements OnInit {
    public journal: UJournal;
    public isViewLoading$: Observable<boolean>;

    constructor(private studentState: Store<StudentState>, private appState: Store<AppState>, private storage: StorageService) {
        this.studentState.pipe(select(selectUJournal)).subscribe(result => this.journal = result);
        this.isViewLoading$ = this.appState.pipe(select(selectViewLoading));
    }

    public ngOnInit() {
        let userId = +this.storage.getValue(UserIdKey);
        this.studentState.dispatch(new ExecuteLoadUJournal({ userId: userId }));
    }
}