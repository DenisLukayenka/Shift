import { Component, Output, EventEmitter, Input, OnChanges, SimpleChanges } from "@angular/core";
import { FormGroup, FormControl } from "@angular/forms";
import * as _ from 'lodash';
import { UJHelperService } from "./uj-helper.service";
import { Report } from "src/app/infrastracture/entities/ujournal/Report";
import { UJournal } from "src/app/infrastracture/entities/ujournal/UJournal";
import { ViewMode } from "src/app/infrastracture/entities/ViewMode";

@Component({
    selector: 'pac-uj-view',
    styleUrls: ['./uj-view.component.scss'],
    templateUrl: './uj-view.component.html',
    providers: [UJHelperService],
})
export class UJViewComponent implements OnChanges {
    public journalOptions: FormGroup;

    @Input() public isViewLoading: boolean;
    @Input() public journal: UJournal;
    @Input() public viewMode?: ViewMode = ViewMode.Student;

    @Output() public onUJSaved: EventEmitter<any> = new EventEmitter<any>();
    
    constructor(public ujHelper: UJHelperService) {}

    public ngOnChanges (changes: SimpleChanges): void {
        if(changes && changes.journal && changes.journal.currentValue) {
            this.journalOptions = this.ujHelper.generateFormOptions(changes.journal.currentValue);
        }
    }
    
    public submitJournal() {
        let formJournal = _.cloneDeep(this.journalOptions.value) as UJournal;
        let researchWorks = _.filter(formJournal.PreparationInfo.ResearchWorks, work => !!work.JobType && !!work.PresentationType);
        let mark = +formJournal.ThesisCertification.Mark;
        let reportResults = _.filter(formJournal.ReportResults, result => !!result.Result);

        formJournal.PreparationInfo.ResearchWorks = researchWorks;
        formJournal.ReportResults = reportResults;
        formJournal.ThesisCertification.Mark = mark;

        this.onUJSaved.emit(formJournal);
    }
}