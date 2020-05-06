import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserContext } from "src/app/infrastracture/responses/UserContext";

export interface AppState {
    appLoading: boolean;
    viewLoading: boolean;
    isErrorOccurs: boolean;
    userContext: UserContext;
    authAlert: string;
}

export const initialState: AppState = {
    appLoading: false,
    viewLoading: false,
    isErrorOccurs: false,
    userContext: undefined,
    authAlert: '',
}

export const selectApp = createFeatureSelector<AppState>('app');
export const selectAppLoading = createSelector(selectApp, state => state.appLoading);
export const selectIsErrorOccurs = createSelector(selectApp, state => state.isErrorOccurs);
export const selectUserContext = createSelector(selectApp, state => state.userContext);
export const selectAuthAlert = createSelector(selectApp, state => state.authAlert);
export const selectViewLoading = createSelector(selectApp, state => state.viewLoading);

