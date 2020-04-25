import { ActionReducerMap } from '@ngrx/store';
import { MenuState } from './menu/menu.state';
import { menuReducer } from './menu/menu.reducer';
import { MenuEffects } from './menu/menu.effects';

export interface State {
    menu: MenuState;
}

export const CoreReducers: ActionReducerMap<State> = {
    menu: menuReducer,
}

export const CoreEffects = [
    MenuEffects,
]