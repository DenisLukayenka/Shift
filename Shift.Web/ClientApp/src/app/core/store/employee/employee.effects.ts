import { Injectable } from "@angular/core";
import { Actions, Effect, ofType } from "@ngrx/effects";
import { StorageService } from "src/app/services/storage/storage.service";
import { Router } from "@angular/router";
import { HttpProcessorService } from "src/app/services/http-processor/http-processor.service";
import { EmployeeActionTypes, LoadGraduates, LoadGraduatesSuccess, LoadUndergraduatesSuccess, LoadUndergraduates } from "./employee.action";
import { map, exhaustMap, catchError } from "rxjs/operators";
import { FetchGraduatesReq } from "src/app/infrastracture/requests/FetchGraduatesReq";
import { AppFailure } from "../app/app.actions";
import { of } from "rxjs";
import { FetchUndergraduatesReq } from "src/app/infrastracture/requests/FetchUndergraduatesReq";

@Injectable()
export class EmployeeEffects {
    @Effect()
    loadGraduates$ = this.actions$.pipe(
        ofType<LoadGraduates>(EmployeeActionTypes.LoadGraduates),
        map(action => action.payload.employeeId),
        exhaustMap(employeeId => this.httpProcessor.execute(new FetchGraduatesReq(employeeId))),
        map(response => {
            if(response) {
                return new LoadGraduatesSuccess({ graduates: response.Graduates });
            } 
            return new AppFailure();
        }),
        catchError(error => of(new AppFailure()))
    );

    @Effect()
    loadUndergraduates$ = this.actions$.pipe(
        ofType<LoadUndergraduates>(EmployeeActionTypes.LoadUndergraduates),
        map(action => action.payload.employeeId),
        exhaustMap(employeeId => this.httpProcessor.execute(new FetchUndergraduatesReq(employeeId))),
        map(response => {
            if(response) {
                return new LoadUndergraduatesSuccess({ undergraduates: response.Undergraduates });
            } 
            return new AppFailure();
        }),
        catchError(error => of(new AppFailure()))
    );

    constructor(
        private actions$: Actions, 
        private storage: StorageService,
        private router: Router,
        private httpProcessor: HttpProcessorService) {}
}