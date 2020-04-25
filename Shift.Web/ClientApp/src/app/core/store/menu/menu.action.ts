import { Action } from '@ngrx/store';

export enum MenuActionTypes {
    MenuToggle = '[Pac] Menu Toggle',
}

export class MenuToggle implements Action {
    readonly type = MenuActionTypes.MenuToggle
};

export type MenuActionsUnion = 
    | MenuToggle;