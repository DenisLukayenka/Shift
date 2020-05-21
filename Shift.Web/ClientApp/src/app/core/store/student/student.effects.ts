import { Injectable } from "@angular/core";
import { Actions, Effect, ofType } from "@ngrx/effects";
import { HttpProcessorService } from "src/app/services/http-processor/http-processor.service";
import { StudentActionTypes, LoadUJournal, LoadUJournalSuccess, SaveUJournalSuccess, SaveUJournal, LoadGJournal, LoadGJournalSuccess, ExecuteLoadUJournal, ExecuteLoadGJournal, SaveGJournal, SaveGJournalSuccess } from "./student.actions";
import { map, exhaustMap, catchError, switchMap } from "rxjs/operators";
import { FetchUJournalReq } from "src/app/infrastracture/requests/journals/undergraduates/FetchUJournalReq";
import { AppFailure, ViewStartLoading, ViewFinishLoading } from "../app/app.actions";
import { of } from "rxjs";
import { SaveUJournalReq } from "src/app/infrastracture/requests/journals/undergraduates/SaveUJournalReq";
import { StorageService } from "src/app/services/storage/storage.service";
import { FetchGJournalReq } from "src/app/infrastracture/requests/journals/graduates/FetchGJournalReq";
import { SaveGJournalReq } from "src/app/infrastracture/requests/journals/graduates/SaveGJournalReq";

@Injectable()
export class StudentEffects {
    @Effect()
    executeLoadUJournal$ = this.actions$.pipe(
        ofType<ExecuteLoadUJournal>(StudentActionTypes.ExecuteLoadUJournal),
        map(action => action.payload.userId),
        switchMap(userId => [
            new ViewStartLoading(),
            new LoadUJournal({ userId: userId })
        ]),
        catchError(error => of(new AppFailure()))
    );

    @Effect()
    executeLoadGJournal$ = this.actions$.pipe(
        ofType<ExecuteLoadGJournal>(StudentActionTypes.ExecuteLoadGJournal),
        map(action => action.payload.userId),
        switchMap(userId => [
            new ViewStartLoading(),
            new LoadGJournal({ userId: userId })
        ]),
        catchError(error => of(new AppFailure()))
    );

    @Effect()
    loadUJournal$ = this.actions$.pipe(
        ofType<LoadUJournal>(StudentActionTypes.LoadUJournal),
        map(action => action.payload.userId),
        exhaustMap(userId => this.httpProcessor.execute(new FetchUJournalReq(userId))),
        switchMap(response => {
            if(response && response.Journal) {
                return [new ViewFinishLoading(), new LoadUJournalSuccess({ journal: response.Journal })];
            } 
            return [new AppFailure()];
        }),
        catchError(error => of(new AppFailure()))
    );

    @Effect()
    saveUJournal$ = this.actions$.pipe(
        ofType<SaveUJournal>(StudentActionTypes.SaveUJournal),
        map(action => action.payload.journal),
        exhaustMap(journal => this.httpProcessor.execute(new SaveUJournalReq(journal))),
        map(response => {
            if(response && response.Message) {
                return new SaveUJournalSuccess({ journal: response.Journal });
            }
            return new AppFailure();
        }),
        catchError(error => of(new AppFailure()))
    );

    @Effect()
    loadGJournal$ = this.actions$.pipe(
        ofType<LoadGJournal>(StudentActionTypes.LoadGJournal),
        map(action => action.payload.userId),
        exhaustMap(userId => this.httpProcessor.execute(new FetchGJournalReq(userId))),
        switchMap(response => {
            if(response && response.Journal) {
                return [new ViewFinishLoading(), new LoadGJournalSuccess({ journal: response.Journal })];
            } 
            return [new AppFailure()];
        }),
        catchError(error => of(new AppFailure()))
    );

    @Effect()
    saveGJournal$ = this.actions$.pipe(
        ofType<SaveGJournal>(StudentActionTypes.SaveGJournal),
        map(action => action.payload.journal),
        exhaustMap(journal => this.httpProcessor.execute(new SaveGJournalReq(journal))),
        map(response => {
            if(response && response.Message) {
                return new SaveGJournalSuccess({ journal: response.Journal });
            }
            return new AppFailure();
        }),
        catchError(error => of(new AppFailure()))
    );

    constructor(
        private actions$: Actions, 
        private httpProcessor: HttpProcessorService) {}
}