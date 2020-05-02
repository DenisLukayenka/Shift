import { Component } from "@angular/core";
import { GJournal } from "src/app/infrastracture/entities/gjournal/GJournal";
import { StorageService } from "src/app/services/storage/storage.service";
import { Store, select } from "@ngrx/store";
import { StudentState, selectGJournal } from "../../store/student/student.state";
import { UserIdKey } from "src/app/services/storage/StorageKeys";
import { LoadGJournal } from "../../store/student/student.actions";
import { Observable } from "rxjs";
import { AppState, selectViewLoading } from "../../store/app/app.state";

@Component({
    selector: 'pac-gj-wrapper',
    templateUrl: './gj-wrapper.component.html'
})
export class GJWrapperComponent {
    public journal: GJournal;
    public isViewLoading$: Observable<boolean>;

    constructor(private studentState: Store<StudentState>, private storage: StorageService, private appState: Store<AppState>) {
        this.studentState.pipe(select(selectGJournal)).subscribe(result => this.journal = result);
        this.isViewLoading$ = this.appState.pipe(select(selectViewLoading));
    }

    public ngOnInit() {
        let userId = +this.storage.getValue(UserIdKey);
        this.studentState.dispatch(new LoadGJournal({ userId: userId }));
    }
}