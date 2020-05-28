import { Component, OnInit, ViewChild, Output, EventEmitter } from "@angular/core";
import { Store, select } from "@ngrx/store";
import { EmployeeState, selectUndergraduates } from "src/app/core/store/employee/employee.state";
import { StorageService } from "src/app/services/storage/storage.service";
import { SpecifiedUserIdKey } from "src/app/services/storage/StorageKeys";
import { LoadUndergraduates } from "src/app/core/store/employee/employee.action";
import { UserContext } from "src/app/infrastracture/entities/users/UserContext";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { StudentState, selectUJournal } from "src/app/core/store/student/student.state";
import { ExecuteLoadUJournal, ResetJournals, SaveUJournal } from "src/app/core/store/student/student.actions";
import { UJournal } from "src/app/infrastracture/entities/ujournal/UJournal";
import { selectViewLoading } from "src/app/core/store/app/app.state";
import { Observable } from "rxjs";
import { ViewMode } from "src/app/infrastracture/entities/ViewMode";

@Component({
    selector: 'pac-uj-list',
    templateUrl: './uj-list.component.html',
    styleUrls: ['./uj-list.component.scss']
})
export class UJournalListComponent implements OnInit {
    displayedColumns: string[] = ['FirstName', 'LastName', 'Journal'];
    dataSource = new MatTableDataSource<UserContext>();

    isJournalOpened = false;
    journal: UJournal;
    selectedUser: UserContext;

    public isViewLoading$: Observable<boolean>;
    public ViewModes = ViewMode;

    @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
    private employeeId: number;

    constructor(private employeeState: Store<EmployeeState>, private studentState: Store<StudentState>, private storageService: StorageService) {
        this.employeeId = +this.storageService.getValue(SpecifiedUserIdKey);
        this.employeeState.pipe(select(selectUndergraduates)).subscribe(users => this.dataSource.data = users);

        this.studentState.pipe(select(selectUJournal)).subscribe(j => {
            if (!!j) {
                this.isJournalOpened = true;
                this.journal = j;
                return;
            }
            this.isJournalOpened = false;
            this.journal = undefined;
            this.selectedUser = undefined;
        });
        this.isViewLoading$ = this.studentState.pipe(select(selectViewLoading));
    }
    
    ngOnInit() {
        this.employeeState.dispatch(new LoadUndergraduates({ employeeId: this.employeeId }));

        this.dataSource.paginator = this.paginator;
    }

    public showJournal(user: UserContext) {
        this.studentState.dispatch(new ExecuteLoadUJournal({ userId: user.UserId }));
        this.selectedUser = user;
    }

    public resetUndergraduateView() {
        this.studentState.dispatch(new ResetJournals());
    }

    public saveJournal(journal: UJournal) {
        this.studentState.dispatch(new SaveUJournal({ journal: journal }));
    }
}