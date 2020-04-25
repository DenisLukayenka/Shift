import { Action } from '@ngrx/store';

export enum AppActionTypes {
    LoadSuccess = '[Pac] App Load Success',
    LoadFailure = '[Pac] App Load Failure',
}

export class LoadSuccess implements Action {
    readonly type = AppActionTypes.LoadSuccess
};

export class LoadFailure implements Action {
    readonly type = AppActionTypes.LoadFailure
};

export type AppActionsUnion = 
    | LoadSuccess
    | LoadFailure;