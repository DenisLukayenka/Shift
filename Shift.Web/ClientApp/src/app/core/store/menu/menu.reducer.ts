import { produce } from 'immer';
import { MenuActionsUnion, MenuActionTypes } from "./menu.action";
import { initialState, MenuState } from './menu.state';

export function menuReducer(state = initialState, action: MenuActionsUnion): MenuState {
    switch(action.type) {
        case MenuActionTypes.MenuToggle:
            return produce(state, draft => {
                draft.menuOpen = !draft.menuOpen;
            });

        default:
            return state;
    }
};