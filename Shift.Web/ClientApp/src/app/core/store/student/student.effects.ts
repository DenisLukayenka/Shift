import { Injectable } from "@angular/core";
import { Actions, Effect, ofType } from "@ngrx/effects";
import { HttpProcessorService } from "src/app/services/http-processor/http-processor.service";
import { StudentActionTypes, LoadUJournal, LoadUJournalSuccess, SaveUJournalSuccess, SaveUJournal } from "./student.actions";
import { map, exhaustMap, catchError, switchMap } from "rxjs/operators";
import { FetchUJournalReq } from "src/app/infrastracture/requests/FetchUJournalReq";
import { AppFailure } from "../app/app.actions";
import { of } from "rxjs";
import { SaveUJournalReq } from "src/app/infrastracture/requests/SaveUJournalReq";
import { StorageService } from "src/app/services/storage/storage.service";
import { UserIdKey } from "src/app/services/storage/StorageKeys";

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
    );

    @Effect()
    saveUJournal$ = this.actions$.pipe(
        ofType<SaveUJournal>(StudentActionTypes.SaveUJournal),
        map(action => action.payload.journal),
        exhaustMap(journal => this.httpProcessor.execute(new SaveUJournalReq(journal))),
        switchMap(response => {
            if(response && response.Message) {
                return [
                    new SaveUJournalSuccess({ message: response.Message }),
                    new LoadUJournal({ userId: +this.storage.getValue(UserIdKey) }),
                ];
            }
            return [new AppFailure()];
        }),
        catchError(error => of(new AppFailure()))
    );

    constructor(
        private actions$: Actions, 
        private httpProcessor: HttpProcessorService,
        private storage: StorageService) {}
}