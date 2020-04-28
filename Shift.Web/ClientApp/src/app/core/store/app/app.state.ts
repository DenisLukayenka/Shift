import { createFeatureSelector, createSelector } from "@ngrx/store";

export interface AppState {
    appLoading: boolean;
    viewLoading: boolean;
    isAuth: boolean;
    isErrorOccurs: boolean;
    authAlert: string;
}

export const initialState: AppState = {
    appLoading: false,
    viewLoading: false,
    isAuth: true,
    isErrorOccurs: false,
    authAlert: ''
}

export const selectApp = createFeatureSelector<AppState>('app');
export const selectAppLoading = createSelector(selectApp, state => state.appLoading);
export const selectIsAuth = createSelector(selectApp, state => state.isAuth);
export const selectIsErrorOccurs = createSelector(selectApp, state => state.isErrorOccurs);
export const selectAuthAlert = createSelector(selectApp, state => state.authAlert);
