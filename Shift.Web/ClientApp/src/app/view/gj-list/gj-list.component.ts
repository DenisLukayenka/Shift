import { Component, OnInit, ViewChild } from "@angular/core";
import { Store, select } from "@ngrx/store";
import { EmployeeState, selectGraduates } from "src/app/core/store/employee/employee.state";
import { StorageService } from "src/app/services/storage/storage.service";
import { SpecifiedUserIdKey } from "src/app/services/storage/StorageKeys";
import { UserContext } from "src/app/infrastracture/entities/users/UserContext";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { LoadGraduates } from "src/app/core/store/employee/employee.action";
import { StudentState, selectGJournal } from "src/app/core/store/student/student.state";
import { ExecuteLoadGJournal, ResetJournals, SaveGJournal } from "src/app/core/store/student/student.actions";
import { GJournal } from "src/app/infrastracture/entities/gjournal/GJournal";
import { Observable } from "rxjs";
import { ViewMode } from "src/app/infrastracture/entities/ViewMode";
import { selectViewLoading } from "src/app/core/store/app/app.state";

@Component({
    selector: 'pac-gj-list',
    templateUrl: './gj-list.component.html',
    styleUrls: ['./gj-list.component.scss'],
})
export class GJournalListComponent implements OnInit {
    displayedColumns: string[] = ['FirstName', 'LastName', 'Journal'];
    dataSource = new MatTableDataSource<UserContext>();
    @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

    isJournalOpened = false;
    journal: GJournal;
    selectedUser: UserContext;

    public isViewLoading$: Observable<boolean>;
    public ViewModes = ViewMode;

    private employeeId: number;

    constructor(private employeeState: Store<EmployeeState>, private studentState: Store<StudentState>, private storageService: StorageService) {
        this.employeeId = +this.storageService.getValue(SpecifiedUserIdKey);
        this.employeeState.pipe(select(selectGraduates)).subscribe(users => this.dataSource.data = users);

        this.studentState.pipe(select(selectGJournal)).subscribe(j => {
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
        this.employeeState.dispatch(new LoadGraduates({ employeeId: this.employeeId }));

        this.dataSource.paginator = this.paginator;
    }

    public showJournal(user: UserContext) {
        this.studentState.dispatch(new ExecuteLoadGJournal({ userId: user.UserId }));
        this.selectedUser = user;
    }

    public resetUndergraduateView() {
        this.studentState.dispatch(new ResetJournals());
    }

    public saveJournal(journal: GJournal) {
        this.studentState.dispatch(new SaveGJournal({ journal: journal }));
    }
}