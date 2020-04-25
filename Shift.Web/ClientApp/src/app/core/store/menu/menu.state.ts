import { createSelector, createFeatureSelector } from '@ngrx/store';

export interface MenuState {
    menuOpen: boolean;
}

export const initialState: MenuState = {
    menuOpen: true
}

export const selectMenu = createFeatureSelector<MenuState>('menu');
export const selectIsOpen = createSelector(selectMenu, (state: MenuState) => state.menuOpen);