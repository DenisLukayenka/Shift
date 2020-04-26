import { createFeatureSelector, createSelector } from "@ngrx/store";

export interface AppState {
    appLoading: boolean;
    viewLoading: boolean;
}

export const initialState: AppState = {
    appLoading: true,
    viewLoading: false,
}

export const selectApp = createFeatureSelector<AppState>('app');
export const selectAppLoading = createSelector(selectApp, state => state.appLoading);

