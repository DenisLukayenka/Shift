import { initialState, AppState } from "./app.state";
import { AppActionsUnion, AppActionTypes } from "./app.actions";
import { produce } from 'immer';

export function appReducer(state = initialState, action: AppActionsUnion): AppState {
    switch (action.type) {
        case AppActionTypes.LoadApp:
            return produce(state, draft => {
                draft.appLoading = true;
            });
        case AppActionTypes.LoadSuccess:
            return produce(state, draft => {
                draft.appLoading = false;
            });
        case AppActionTypes.LoadFailure:
            return produce(state, draft => {
                draft.appLoading = false;
            });
        case AppActionTypes.AuthSuccess:
            return produce(state, draft => {
                draft.isAuth = true;
                draft.authAlert = '';
            });
        case AppActionTypes.AuthFailure:
            return produce(state, draft => {
                draft.isAuth = false;
                draft.authAlert = action.payload.alert;
            });
        case AppActionTypes.LogOut:
            return produce(state, draft => {
                draft.appLoading = true;
            });
        case AppActionTypes.LogOutSuccess:
            return produce(state, draft => {
                draft.appLoading = false;
                draft.isAuth = false;
                draft.authAlert = '';
            });
        case AppActionTypes.AppFailure:
            return produce(state, draft => {
                draft.isErrorOccurs = true;
            });
    
        default:
            return state;
    }
}