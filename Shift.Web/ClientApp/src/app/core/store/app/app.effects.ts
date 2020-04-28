import { Injectable } from "@angular/core";
import { Actions, Effect, ofType } from '@ngrx/effects';
import { AppState } from "./app.state";
import { Store } from '@ngrx/store';
import { AppActionTypes, LoadApp, LoadFailure, TryAuth, AuthFailure, AuthSuccess, LogOutSuccess, LogOut, AppFailure } from "./app.actions";
import { switchMap, catchError, exhaustMap, map, tap } from "rxjs/operators";
import { of, from } from "rxjs";
import { HttpProcessorService } from "src/app/services/http-processor/http-processor.service";
import { AuthReq } from "src/app/infrastracture/requests/AuthReq";
import { AuthResponse } from "src/app/infrastracture/responses/AuthResponse";
import { TokenStorageService } from "../../../services/token/token-storage.service";
import { Router } from "@angular/router";
import { FetchRootMenu } from "../menu/menu.action";

@Injectable()
export class AppEffects {
    @Effect()
    loadApp$ = this.actions$.pipe(
        ofType<LoadApp>(AppActionTypes.LoadApp),
        switchMap(() => {
            let userRole = this.storage.getUserRole();

            return [
                new FetchRootMenu({ userRole: userRole }),
            ]
        }),
        catchError(error => of(new AppFailure()))
    );

    @Effect()
    tryAuth$ = this.actions$.pipe(
        ofType<TryAuth>(AppActionTypes.TryAuth),
        exhaustMap((action) => from(this.httpProcessor.execute(new AuthReq(action.payload.login, action.payload.password)))),
        map((response: AuthResponse) => {
            if(response === undefined) {
                return new AppFailure();
            }
            var alert = response.Alert;
            if(response.Alert !== undefined) {
                return new AuthFailure({ alert });
            }
            if(response.Token === undefined) {
                return new AuthFailure({ alert: 'Token not provided' });
            }

            this.storage.addToken(response.Token);
            this.router.navigate(["/"]);
            return new AuthSuccess();
        }),
        catchError(error => of(new AppFailure()))
    );

    @Effect()
    logOut$ = this.actions$.pipe(
        ofType<LogOut>(AppActionTypes.LogOut),
        map(() => {
            this.storage.removeToken();
            this.router.navigate(['login']);

            return new LogOutSuccess();
        })
    );

    constructor(
        private actions$: Actions, 
        private httpProcessor: HttpProcessorService,
        private storage: TokenStorageService,
        private router: Router) {}
}