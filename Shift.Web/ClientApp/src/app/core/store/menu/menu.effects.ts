import { Injectable } from "@angular/core";
import { Actions, Effect, ofType } from '@ngrx/effects';
import { MenuState } from "./menu.state";
import { Store } from '@ngrx/store';
import { FetchRootMenu, MenuActionTypes, FetchRootMenuFailure, FetchRootMenuSuccess } from "./menu.action";
import { from, of } from 'rxjs';
import * as _ from 'lodash';
import { exhaustMap, map, catchError, switchMap } from 'rxjs/operators';
import { HttpProcessorService } from "src/app/services/http-processor/http-processor.service";
import { isRootMenuResponse } from "src/app/infrastracture/utilities/isRootMenuResponse";
import { FetchRootMenuResp } from "src/app/infrastracture/responses/FetchRootMenuResp";
import { FetchRootMenuReq } from "src/app/infrastracture/requests/FetchRootMenuReq";
import { LoadSuccess } from "../app/app.actions";

@Injectable()
export class MenuEffects {
    @Effect()
    fetchRootMenu$ = this.actions$.pipe(
        ofType<FetchRootMenu>(MenuActionTypes.FetchRootMenu),
        map(action => action.payload.userRole),
        exhaustMap((userRole) => from(this.httpProcessor.execute(new FetchRootMenuReq(userRole)))),
        switchMap((response: FetchRootMenuResp) => {
            if(!!response) {
                return [ new FetchRootMenuSuccess({ menu: response.RootMenu }), new LoadSuccess() ];
            } else {
                return [ new FetchRootMenuFailure() ];
            }
        }),
        catchError(error => of(new FetchRootMenuFailure()))
    );

    constructor(
        private actions$: Actions, 
        private menuStore: Store<MenuState>,
        private httpProcessor: HttpProcessorService) {}
}