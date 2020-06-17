import { Injectable } from "@angular/core";
import { Actions, Effect, ofType } from "@ngrx/effects";
import { HttpProcessorService } from "src/app/services/http-processor/http-processor.service";
import { StudentActionTypes, LoadUJournal, LoadUJournalSuccess, SaveUJournalSuccess, SaveUJournal, LoadGJournal, LoadGJournalSuccess, ExecuteLoadUJournal, ExecuteLoadGJournal, SaveGJournal, SaveGJournalSuccess, DownloadUJournal, DownloadUJournalSuccess, DownloadGJournal } from "./student.actions";
import { map, exhaustMap, catchError, switchMap } from "rxjs/operators";
import { FetchUJournalReq } from "src/app/infrastracture/requests/journals/undergraduates/FetchUJournalReq";
import { AppFailure, ViewStartLoading, ViewFinishLoading } from "../app/app.actions";
import { of } from "rxjs";
import { SaveUJournalReq } from "src/app/infrastracture/requests/journals/undergraduates/SaveUJournalReq";
import { StorageService } from "src/app/services/storage/storage.service";
import { FetchGJournalReq } from "src/app/infrastracture/requests/journals/graduates/FetchGJournalReq";
import { SaveGJournalReq } from "src/app/infrastracture/requests/journals/graduates/SaveGJournalReq";
import { DownloadUJournalReq } from "src/app/infrastracture/requests/journals/undergraduates/DownloadUJournalReq";
import { DownloadGJournalReq } from "src/app/infrastracture/requests/journals/graduates/DownloadGJournalReq";

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
        switchMap(response => {
            if(response && response.Message) {
                return [new ViewFinishLoading(), new SaveUJournalSuccess({ journal: response.Journal })];
            }
            return [new AppFailure()];
        }),
        catchError(error => of(new AppFailure()))
    );

    @Effect()
    downloadUJournal$ = this.actions$.pipe(
        ofType<DownloadUJournal>(StudentActionTypes.DownloadUJournal),
        exhaustMap(action => this.httpProcessor.execute(new DownloadUJournalReq(action.payload.userId))),
        map((response) => {
            const blob = new Blob([response], { type: 'application/vnd.openxmlformats-officedocument.wordprocessingml.document'});
            const data = URL.createObjectURL(blob);

            let link = document.createElement('a');
            link.setAttribute('type', 'hidden');
            link.href = data;
            link.download = 'ПланМагистранта' + '.docx';
            link.dispatchEvent(new MouseEvent('click', { bubbles: true, cancelable: true, view: window }));
            setTimeout(function () {
                window.URL.revokeObjectURL(data);
                link.remove();
            }, 100);

            return new ViewFinishLoading();
        }),
        catchError(error => of(new AppFailure()))
    );

    @Effect()
    downloadGJournal$ = this.actions$.pipe(
        ofType<DownloadGJournal>(StudentActionTypes.DownloadGJournal),
        exhaustMap(action => this.httpProcessor.execute(new DownloadGJournalReq(action.payload.userId))),
        map((response) => {
            const blob = new Blob([response], { type: 'application/vnd.openxmlformats-officedocument.wordprocessingml.document'});
            const data = URL.createObjectURL(blob);

            let link = document.createElement('a');
            link.setAttribute('type', 'hidden');
            link.href = data;
            link.download = 'ПланАспиранта' + '.docx';
            link.dispatchEvent(new MouseEvent('click', { bubbles: true, cancelable: true, view: window }));
            setTimeout(function () {
                window.URL.revokeObjectURL(data);
                link.remove();
            }, 100);

            return new ViewFinishLoading();
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
        switchMap(response => {
            if(response && response.Message) {
                return [new ViewFinishLoading(), new SaveGJournalSuccess({ journal: response.Journal })];
            }
            return [new AppFailure()];
        }),
        catchError(error => of(new AppFailure()))
    );

    constructor(
        private actions$: Actions, 
        private httpProcessor: HttpProcessorService) {}
}