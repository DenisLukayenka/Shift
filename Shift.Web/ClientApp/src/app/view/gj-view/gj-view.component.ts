import { Component, Input, SimpleChanges, OnInit, OnChanges } from "@angular/core";
import { GJournal } from "src/app/infrastracture/entities/gjournal/GJournal";
import { FormGroup } from "@angular/forms";
import { Store } from "@ngrx/store";
import { StudentState } from "src/app/core/store/student/student.state";
import * as _ from 'lodash';
import { GJHelperService } from "./gj-helper.service";

@Component({
    selector: 'pac-gj-view',
    styleUrls: ['./gj-view.component.scss'],
    templateUrl: './gj-view.component.html',
    providers: [GJHelperService]
})
export class GraduateJournalComponent implements OnChanges {
    @Input() public journal: GJournal;
    public journalOptions: FormGroup;

    constructor(
        private studentState: Store<StudentState>,
        private gjHelper: GJHelperService
    ){}

    ngOnChanges (changes: SimpleChanges ): void {
        if(changes.journal.currentValue) {
            this.journalOptions = this.gjHelper.generateFormGroup(changes.journal.currentValue);
        }
    }

    public submitJournal() {
        let formJournal = _.cloneDeep(this.journalOptions.value);
        console.log(formJournal);
    }
}