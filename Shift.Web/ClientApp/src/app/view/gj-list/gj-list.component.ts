import { Component, OnInit } from "@angular/core";
import { Store } from "@ngrx/store";
import { EmployeeState } from "src/app/core/store/employee/employee.state";
import { StorageService } from "src/app/services/storage/storage.service";
import { SpecifiedUserIdKey } from "src/app/services/storage/StorageKeys";
import { LoadGraduates } from "src/app/core/store/employee/employee.action";

@Component({
    selector: 'pac-gj-list',
    templateUrl: './gj-list.component.html'
})
export class GJournalListComponent implements OnInit {
    private employeeId: number;

    constructor(private employeeState: Store<EmployeeState>, private storageService: StorageService) {
        this.employeeId = +this.storageService.getValue(SpecifiedUserIdKey);
    }
    
    ngOnInit() {
        this.employeeState.dispatch(new LoadGraduates({ employeeId: this.employeeId }));
    }
}