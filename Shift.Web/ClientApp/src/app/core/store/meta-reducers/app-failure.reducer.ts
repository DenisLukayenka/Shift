import { ActionReducer } from "@ngrx/store";
import { AppActionTypes } from "../app/app.actions";

export function appFailureReducer(reducer: ActionReducer<any>): ActionReducer<any> {
    return function(state, action) {
        switch (action.type) {
            case AppActionTypes.AppFailure: 
                state = undefined;
                break;
        }

        return reducer(state, action);
    }
}