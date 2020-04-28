import { Injectable } from "@angular/core";
import { Actions, Effect, ofType } from '@ngrx/effects';
import { AppActionTypes, LoadApp, LogOutSuccess, LogOut, AppFailure } from "./app.actions";
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