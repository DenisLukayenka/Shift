import { ActionReducer } from "@ngrx/store";
import { AppActionTypes } from "../app/app.actions";

export function logoutReducer(reducer: ActionReducer<any>): ActionReducer<any> {
    return function(state, action) {
        switch (action.type) {
            case AppActionTypes.LogOut: 
                state = undefined;
                break;
        }

        return reducer(state, action);
    }
}