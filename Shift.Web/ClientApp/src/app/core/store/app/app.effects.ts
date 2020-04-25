import { Injectable } from "@angular/core";
import { Actions } from '@ngrx/effects';
import { AppState } from "./app.state";
import { Store } from '@ngrx/store';

@Injectable()
export class AppEffects {

    constructor(private actions$: Actions, private aboutVersionStore: Store<AppState>) {}
}