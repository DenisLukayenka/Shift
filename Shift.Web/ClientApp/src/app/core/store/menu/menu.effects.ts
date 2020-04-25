import { Injectable } from "@angular/core";
import { Actions } from '@ngrx/effects';
import { MenuState } from "./menu.state";
import { Store } from '@ngrx/store';

@Injectable()
export class MenuEffects {

    constructor(private actions$: Actions, private aboutVersionStore: Store<MenuState>) {}
}