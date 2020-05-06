import { Injectable } from "@angular/core";
import { Actions, Effect, ofType } from '@ngrx/effects';
import { FetchRootMenu, MenuActionTypes, FetchRootMenuFailure, FetchRootMenuSuccess } from "./menu.action";
import { from, of } from 'rxjs';
import * as _ from 'lodash';
import { exhaustMap, map, catchError, switchMap } from 'rxjs/operators';
import { HttpProcessorService } from "src/app/services/http-processor/http-processor.service";
import { FetchRootMenuResp } from "src/app/infrastracture/responses/FetchRootMenuResp";
import { FetchRootMenuReq } from "src/app/infrastracture/requests/FetchRootMenuReq";
import { LoadSuccess, AppFailure } from "../app/app.actions";
import { Router } from "@angular/router";
import { RootPage } from "src/app/infrastracture/config";

@Injectable()
export class MenuEffects {
    @Effect()
    fetchRootMenu$ = this.actions$.pipe(
        ofType<FetchRootMenu>(MenuActionTypes.FetchRootMenu),
        map(action => action.payload.userId),
        exhaustMap((userId) => from(this.httpProcessor.execute(new FetchRootMenuReq(userId)))),
        switchMap((response: FetchRootMenuResp) => {
            if(!!response && response.RootMenu && response.Role) {
                this.router.navigateByUrl(RootPage + '/' + response.Role);

                return [ new FetchRootMenuSuccess({ menu: response.RootMenu }), new LoadSuccess() ];
            } else {
                return [ new FetchRootMenuFailure() ];
            }
        }),
        catchError(error => of(new AppFailure()))
    );

    constructor(
        private actions$: Actions,
        private httpProcessor: HttpProcessorService,
        private router: Router) {}
}