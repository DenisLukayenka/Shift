import { Injectable } from "@angular/core";
import { Actions, Effect, ofType } from '@ngrx/effects';
import { AppActionTypes, LoadApp, LogOutSuccess, LogOut, AppFailure, TryAuth, AuthSuccess, AuthFailure, FetchDefaultRoute, FetchDefaultRouteSuccess, ErrorPageNavigated, ViewFinishLoading } from "./app.actions";
import { switchMap, catchError, map, exhaustMap, tap } from "rxjs/operators";
import { of } from "rxjs";
import { Router } from "@angular/router";
import { FetchRootMenu } from "../menu/menu.action";
import { StorageService } from "src/app/services/storage/storage.service";
import { UserIdKey, TokenKey } from "src/app/services/storage/StorageKeys";
import { LoginPage, RootPage, ViewTypeQueryParam, ErrorPage } from "src/app/infrastracture/config";
import { HttpProcessorService } from "src/app/services/http-processor/http-processor.service";
import { AuthReq } from "src/app/infrastracture/requests/AuthReq";
import { AuthResponse } from "src/app/infrastracture/responses/AuthResponse";
import { FetchDefaultRouteReq } from "src/app/infrastracture/requests/FetchDefaultRouteReq";

@Injectable()
export class AppEffects {
    @Effect()
    loadApp$ = this.actions$.pipe(
        ofType<LoadApp>(AppActionTypes.LoadApp),
        switchMap(() => {
            let userId = +this.storage.getValue(UserIdKey);

            return [
                new FetchRootMenu({ userId: userId }),
                new FetchDefaultRoute({ userId: userId }),
            ]
        }),
        catchError(error => of(new AppFailure()))
    );
    
    @Effect()
    logOut$ = this.actions$.pipe(
        ofType<LogOut>(AppActionTypes.LogOut),
        map(() => {
            this.storage.clear();
            this.router.navigate([LoginPage]);

            return new LogOutSuccess();
        }),
        catchError(error => of(new AppFailure()))
    );

    @Effect()
    fetchDefaultRoute$ = this.actions$.pipe(
        ofType<FetchDefaultRoute>(AppActionTypes.FetchDefaultRoute),
        map(action => action.payload.userId),
        exhaustMap(userId => this.httpProcessor.execute(new FetchDefaultRouteReq(userId))),
        map(response => {
            if(!response.DefaultRoute) {
                return new AppFailure();
            }
            this.router.navigate([], {
                queryParams: { [ViewTypeQueryParam]: response.DefaultRoute }
            });

            return new FetchDefaultRouteSuccess({ defaultRoute: response.DefaultRoute });
        }),
        catchError(error => of(new AppFailure()))
    );

    @Effect()
    tryAuth$ = this.actions$.pipe(
        ofType<TryAuth>(AppActionTypes.TryAuth),
        map(action => action.payload),
        exhaustMap(data => this.httpProcessor.execute(new AuthReq(data.login, data.password))),
        map((response: AuthResponse) => {
            if(response.Alert) {
                return new AuthFailure({ alert: response.Alert });
            }
            this.storage.setValue(TokenKey, response.Token);
            this.storage.setValue(UserIdKey, response.User.UserId.toString());
            this.router.navigate([RootPage]);

            return new AuthSuccess({ userContext: response.User });
        }),
        catchError(error => of(new AppFailure()))
    );

    @Effect()
    appFailure$ = this.actions$.pipe(
        ofType<AppFailure>(AppActionTypes.AppFailure),
        tap(() => {
            this.router.navigate([ErrorPage]);
        }),
        switchMap(() => [new ViewFinishLoading(), new ErrorPageNavigated()]),
    );

    constructor(
        private actions$: Actions, 
        private storage: StorageService,
        private router: Router,
        private httpProcessor: HttpProcessorService) {}
}