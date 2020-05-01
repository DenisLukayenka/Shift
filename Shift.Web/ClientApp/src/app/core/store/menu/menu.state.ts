import { createSelector, createFeatureSelector } from '@ngrx/store';
import { RootMenu } from 'src/app/infrastracture/entities/menu/RootMenu';

export interface MenuState {
    menuOpen: boolean;
    menu: RootMenu;
}

export const initialState: MenuState = {
    menuOpen: false,
    menu: {
        MenuGroups: []
    },
}

export const selectMenu = createFeatureSelector<MenuState>('menu');
export const selectIsOpen = createSelector(selectMenu, state => state.menuOpen);
export const selectRootMenu = createSelector(selectMenu, state => state.menu);