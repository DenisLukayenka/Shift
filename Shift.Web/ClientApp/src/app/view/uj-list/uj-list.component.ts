import { Component, OnInit } from "@angular/core";
import { Store } from "@ngrx/store";
import { EmployeeState } from "src/app/core/store/employee/employee.state";
import { StorageService } from "src/app/services/storage/storage.service";
import { SpecifiedUserIdKey } from "src/app/services/storage/StorageKeys";
import { LoadUndergraduates } from "src/app/core/store/employee/employee.action";

@Component({
    selector: 'pac-uj-list',
    templateUrl: './uj-list.component.html',
})
export class UJournalListComponent implements OnInit {
    private employeeId: number;

    constructor(private employeeState: Store<EmployeeState>, private storageService: StorageService) {
        this.employeeId = +this.storageService.getValue(SpecifiedUserIdKey);
    }
    
    ngOnInit() {
        this.employeeState.dispatch(new LoadUndergraduates({ employeeId: this.employeeId }));
    }
}