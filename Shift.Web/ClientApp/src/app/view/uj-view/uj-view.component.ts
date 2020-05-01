import { Component, OnInit, NgZone, ViewChild } from "@angular/core";
import { StudentState, selectUJournal } from "src/app/core/store/student/student.state";
import { Store, select } from "@ngrx/store";
import { UJournal } from "src/app/infrastracture/entities/ujournal/UJournal";
import { StorageService } from "src/app/services/storage/storage.service";
import { UserIdKey } from "src/app/services/storage/StorageKeys";
import { LoadUJournal } from "src/app/core/store/student/student.actions";
import { FormBuilder, FormGroup } from "@angular/forms";
import { take } from "rxjs/operators";
import { CdkTextareaAutosize } from "@angular/cdk/text-field";

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
                PreparationSubmittedDate: [''],
                PreparationApprovedDate: [{ value: '', disabled: true }],
                IsPreparationSubmitted: [false],
                IsPreparationApproved: [false],
                IsResearchSubmitted: [false],
                IsResearchApproved: [false],
            }),
        })
    }

    public saveGroup(chapter: string){
        console.log(this.journalOptions.controls[chapter].value);
    }
}