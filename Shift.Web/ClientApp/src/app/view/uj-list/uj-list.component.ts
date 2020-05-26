import { Component, OnInit, ViewChild } from "@angular/core";
import { Store, select } from "@ngrx/store";
import { EmployeeState, selectUndergraduates } from "src/app/core/store/employee/employee.state";
import { StorageService } from "src/app/services/storage/storage.service";
import { SpecifiedUserIdKey } from "src/app/services/storage/StorageKeys";
import { LoadUndergraduates } from "src/app/core/store/employee/employee.action";
import { UserContext } from "src/app/infrastracture/entities/users/UserContext";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";

@Component({
    selector: 'pac-uj-list',
    templateUrl: './uj-list.component.html',
    styleUrls: ['./uj-list.component.scss']
})
export class UJournalListComponent implements OnInit {
    displayedColumns: string[] = ['FirstName', 'LastName', 'Journal'];
    dataSource = new MatTableDataSource<UserContext>();

    @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
    private employeeId: number;

    constructor(private employeeState: Store<EmployeeState>, private storageService: StorageService) {
        this.employeeId = +this.storageService.getValue(SpecifiedUserIdKey);
        this.employeeState.pipe(select(selectUndergraduates)).subscribe(users => this.dataSource.data = users);
    }
    
    ngOnInit() {
        this.employeeState.dispatch(new LoadUndergraduates({ employeeId: this.employeeId }));

        this.dataSource.paginator = this.paginator;
    }

    public showJournal(userId: number) {
        console.log(userId);
    }
}