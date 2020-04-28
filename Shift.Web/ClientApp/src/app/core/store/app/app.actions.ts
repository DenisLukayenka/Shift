import { Action } from '@ngrx/store';

export enum AppActionTypes {
    LoadApp = '[Pac] Load App',
    LoadSuccess = '[Pac] App Load Success',
    LoadFailure = '[Pac] App Load Failure',
    
    AppFailure = '[Pac] App Failure',
    LogOut = '[Pac] Log out',
    LogOutSuccess = '[Pac] Log out Success',
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

export class AppFailure implements Action {
    readonly type = AppActionTypes.AppFailure;
}

export class LogOut implements Action {
    readonly type = AppActionTypes.LogOut;
}

export class LogOutSuccess implements Action {
    readonly type = AppActionTypes.LogOutSuccess;
}

export type AppActionsUnion = 
    | LoadSuccess
    | LoadFailure
    | LoadApp
    
    | LogOut
    | LogOutSuccess
    
    | AppFailure;