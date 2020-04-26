import { Injectable } from "@angular/core";
import { Actions, Effect, ofType } from '@ngrx/effects';
import { AppState } from "./app.state";
import { Store } from '@ngrx/store';
import { AppActionTypes, LoadApp, LoadFailure, LoadSuccess } from "./app.actions";
import { map, switchMap, catchError, combineLatest, finalize, endWith, concat } from "rxjs/operators";
import { FetchRootMenu } from "../menu/menu.action";
import { of } from "rxjs";

@Injectable()
export class AppEffects {
    @Effect()
    loadApp$ = this.actions$.pipe(
        ofType<LoadApp>(AppActionTypes.LoadApp),
        switchMap(() => [
            new FetchRootMenu(),
        ]),
        catchError(error => of(new LoadFailure()))
    );

    constructor(private actions$: Actions, private appStore: Store<AppState>) {}
}