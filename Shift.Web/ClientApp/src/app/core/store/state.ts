import { ActionReducerMap } from '@ngrx/store';
import { MenuState } from './menu/menu.state';
import { menuReducer } from './menu/menu.reducer';
import { MenuEffects } from './menu/menu.effects';
import { AppState } from './app/app.state';
import { appReducer } from './app/app.reducer';
import { AppEffects } from './app/app.effects';
import { StudentState } from './student/student.state';
import { studentReducer } from './student/student.reducer';
import { StudentEffects } from './student/student.effects';

export interface State {
    menu: MenuState;
    app: AppState;
    student: StudentState;
}

export const CoreReducers: ActionReducerMap<State> = {
    menu: menuReducer,
    app: appReducer,
    student: studentReducer,
}

export const CoreEffects = [
    MenuEffects,
    AppEffects,
    StudentEffects,
]