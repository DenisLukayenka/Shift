import { createFeatureSelector, createSelector } from "@ngrx/store";

export interface AppState {
    appLoading: boolean;
    viewLoading: boolean;
    isAuth: boolean;
}

export const initialState: AppState = {
    appLoading: false,
    viewLoading: false,
    isAuth: false,
}

export const selectApp = createFeatureSelector<AppState>('app');
export const selectAppLoading = createSelector(selectApp, state => state.appLoading);
export const selectIsAuth = createSelector(selectApp, state => state.isAuth);

