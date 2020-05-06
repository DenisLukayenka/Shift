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
                draft.authAlert = '';
            });
        case AppActionTypes.LoadFailure:
            return produce(state, draft => {
                draft.appLoading = false;
            });
        case AppActionTypes.LogOut:
            return produce(state, draft => {
                draft.appLoading = true;
            });
        case AppActionTypes.LogOutSuccess:
            return produce(state, draft => {
                draft.appLoading = false;
                draft.authAlert = '';
            });
        case AppActionTypes.ErrorPageNavigated:
            return produce(state, draft => {
                draft.isErrorOccurs = true;
            });
        case AppActionTypes.AuthSuccess:
            return produce(state, draft => {
                draft.userContext = action.payload.userContext;
            });
        case AppActionTypes.AuthFailure:
            return produce(state, draft => {
                draft.authAlert = action.payload.alert;
            });
        case AppActionTypes.ViewFinishLoading:
            return produce(state, draft => {
                draft.viewLoading = false;
            });
        case AppActionTypes.ViewStartLoading:
            return produce(state, draft => {
                draft.viewLoading = true;
            });
    
        default:
            return state;
    }
}