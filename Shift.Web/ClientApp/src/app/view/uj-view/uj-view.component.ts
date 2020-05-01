import { Component, OnInit } from "@angular/core";
import { StudentState, selectUJournal } from "src/app/core/store/student/student.state";
import { Store, select } from "@ngrx/store";
import { UJournal } from "src/app/infrastracture/entities/ujournal/UJournal";
import { StorageService } from "src/app/services/storage/storage.service";
import { UserIdKey } from "src/app/services/storage/StorageKeys";
import { LoadUJournal } from "src/app/core/store/student/student.actions";

@Component({
    selector: 'pac-uj-view',
    styleUrls: ['./uj-view.component.scss'],
    templateUrl: './uj-view.component.html',
})
export class UndergraduateJournalComponent implements OnInit {
    public journal: UJournal;

    constructor(private studentState: Store<StudentState>, private storage: StorageService) {
        this.studentState.pipe(select(selectUJournal)).subscribe(j => this.journal = j);
    }

    ngOnInit() {
        let userId = +this.storage.getValue(UserIdKey);

        this.studentState.dispatch(new LoadUJournal({ userId: userId }));
    }
}