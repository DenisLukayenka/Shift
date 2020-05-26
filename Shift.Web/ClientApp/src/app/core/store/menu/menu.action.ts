import { Action } from '@ngrx/store';
import { RootMenu } from 'src/app/infrastracture/entities/menu/RootMenu';
import { UserContext } from 'src/app/infrastracture/entities/users/UserContext';

export enum MenuActionTypes {
    MenuToggle = '[Pac] Menu Toggle',
    FetchRootMenu = '[Pac] Fetch Root Menu',
    FetchRootMenuSuccess = '[Pac] Fetch Root Menu Success',
    FetchRootMenuFailure = '[Pac] Fetch Root Menu Failure',
}

export class MenuToggle implements Action {
    readonly type = MenuActionTypes.MenuToggle;
};

export class FetchRootMenu implements Action {
    readonly type = MenuActionTypes.FetchRootMenu;

    constructor(public payload: { userId: number }){}
};

export class FetchRootMenuSuccess implements Action {
    readonly type = MenuActionTypes.FetchRootMenuSuccess;

    constructor(public payload: { menu: RootMenu }) {}
};

export class FetchRootMenuFailure implements Action {
    readonly type = MenuActionTypes.FetchRootMenuFailure;
};


export type MenuActionsUnion = 
    | MenuToggle
    | FetchRootMenu
    | FetchRootMenuSuccess
    | FetchRootMenuFailure;