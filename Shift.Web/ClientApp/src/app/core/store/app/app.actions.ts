import { Action } from '@ngrx/store';
import { RootMenu } from 'src/app/infrastracture/entities/menu/RootMenu';

export enum AppActionTypes {
    LoadApp = '[Pac] Load App',
    LoadSuccess = '[Pac] App Load Success',
    LoadFailure = '[Pac] App Load Failure',
}

export class LoadApp implements Action {
    readonly type = AppActionTypes.LoadApp;
};

export class LoadSuccess implements Action {
    readonly type = AppActionTypes.LoadSuccess;
}

export class LoadFailure implements Action {
    readonly type = AppActionTypes.LoadFailure;
};

export type AppActionsUnion = 
    | LoadSuccess
    | LoadFailure
    | LoadApp;