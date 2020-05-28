import { Component, Input, EventEmitter, Output, OnChanges, SimpleChanges } from "@angular/core";
import { FormGroup } from "@angular/forms";
import * as _ from 'lodash';
import { GJHelperService } from "./gj-helper.service";
import { GJournal } from "src/app/infrastracture/entities/gjournal/GJournal";
import { ViewMode } from "src/app/infrastracture/entities/ViewMode";

@Component({
    selector: 'pac-gj-view',
    styleUrls: ['./gj-view.component.scss'],
    templateUrl: './gj-view.component.html',
    providers: [GJHelperService]
})
export class GJViewComponent implements OnChanges {
    public journalOptions: FormGroup;

    @Input() public isViewLoading: boolean;
    @Input() public journal: GJournal;
    @Input() public viewMode?: ViewMode = ViewMode.Student;

    @Output() public onJSaved: EventEmitter<GJournal> = new EventEmitter<GJournal>();
    @Output() public onJDownload: EventEmitter<{}> = new EventEmitter<{}>();

    constructor(public gjHelper: GJHelperService) { }

    public ngOnChanges (changes: SimpleChanges): void {
        if(changes && changes.journal && changes.journal.currentValue) {
            this.journalOptions = this.gjHelper.generateFormGroup(changes.journal.currentValue);
        }
    }

    public submitJournal() {
        this.onJSaved.emit(this.journalOptions.value);
    }

    public downloadJournal() {
        this.onJDownload.emit();
    }
}