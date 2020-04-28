import { createFeatureSelector, createSelector } from "@ngrx/store";

export interface AppState {
    appLoading: boolean;
    viewLoading: boolean;
    isErrorOccurs: boolean;
}

export const initialState: AppState = {
    appLoading: false,
    viewLoading: false,
    isErrorOccurs: false,
}

export const selectApp = createFeatureSelector<AppState>('app');
export const selectAppLoading = createSelector(selectApp, state => state.appLoading);
export const selectIsErrorOccurs = createSelector(selectApp, state => state.isErrorOccurs);
