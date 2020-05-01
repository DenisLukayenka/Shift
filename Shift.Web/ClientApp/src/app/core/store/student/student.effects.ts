import { Injectable } from "@angular/core";
import { Actions, Effect, ofType } from "@ngrx/effects";
import { HttpProcessorService } from "src/app/services/http-processor/http-processor.service";
import { StudentActionTypes, LoadUJournal, LoadUJournalSuccess } from "./student.actions";
import { map, exhaustMap, catchError } from "rxjs/operators";
import { FetchUJournalReq } from "src/app/infrastracture/requests/FetchUJournalReq";
import { AppFailure } from "../app/app.actions";
import { of } from "rxjs";

@Injectable()
export class StudentEffects {
    @Effect()
    loadUJournal$ = this.actions$.pipe(
        ofType<LoadUJournal>(StudentActionTypes.LoadUJournal),
        map(action => action.payload.userId),
        exhaustMap(userId => this.httpProcessor.execute(new FetchUJournalReq(userId))),
        map(response => {
            if(response && response.Journal) {
                return new LoadUJournalSuccess({ journal: response.Journal });
            } 
            return new AppFailure();
        }),
        catchError(error => of(new AppFailure()))
    )

    constructor(
        private actions$: Actions, 
        private httpProcessor: HttpProcessorService) {}
}