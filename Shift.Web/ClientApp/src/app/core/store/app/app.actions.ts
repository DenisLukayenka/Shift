import { Action } from '@ngrx/store';
import { UserContext } from 'src/app/infrastracture/responses/UserContext';

export enum AppActionTypes {
    LoadApp = '[Pac] Load App',
    LoadSuccess = '[Pac] App Load Success',
    LoadFailure = '[Pac] App Load Failure',
    
    AppFailure = '[Pac] App Failure',
    ErrorPageNavigated = '[Pac] Error page navigated',
    LogOut = '[Pac] Log out',
    LogOutSuccess = '[Pac] Log out Success',
    AuthSuccess = '[Pac] Auth Success',
    TryAuth = '[Pac] Try Auth',
    AuthFailure = '[Pac] Auth Failure',

    ViewStartLoading = '[Pac] View Start Loading',
    ViewFinishLoading = '[Pac] View Finish Loading',
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

export class AuthSuccess implements Action {
    readonly type = AppActionTypes.AuthSuccess;

    constructor(public payload: { userContext: UserContext }) {}
}

export class TryAuth implements Action {
    readonly type = AppActionTypes.TryAuth;

    constructor(public payload: { login: string, password: string }) {}
}

export class AuthFailure implements Action {
    readonly type = AppActionTypes.AuthFailure;

    constructor(public payload: { alert: string }) {}
}

export class ErrorPageNavigated implements Action {
    readonly type = AppActionTypes.ErrorPageNavigated;
}

export class ViewStartLoading implements Action {
    readonly type = AppActionTypes.ViewStartLoading;
}

export class ViewFinishLoading implements Action {
    readonly type = AppActionTypes.ViewFinishLoading;
}

export type AppActionsUnion = 
    | LoadSuccess
    | LoadFailure
    | LoadApp
    
    | LogOut
    | LogOutSuccess
    | AuthSuccess
    | TryAuth
    | AuthFailure
    
    | AppFailure
    | ErrorPageNavigated
    
    | ViewStartLoading
    | ViewFinishLoading;