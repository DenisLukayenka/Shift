import { Injectable } from "@angular/core";
import { Effect, ofType, Actions } from '@ngrx/effects';
import { MenuState } from "./menu.state";
import { Store, select } from '@ngrx/store';
import { MenuToggle, MenuActionTypes } from "./menu.action";
import { switchMap, map, withLatestFrom } from "rxjs/operators";

@Injectable()
export class MenuEffects {

    constructor(private actions$: Actions, private aboutVersionStore: Store<MenuState>) {}
}