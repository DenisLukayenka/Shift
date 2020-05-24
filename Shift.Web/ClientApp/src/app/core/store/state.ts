import { ActionReducerMap, MetaReducer } from '@ngrx/store';
import { MenuState } from './menu/menu.state';
import { menuReducer } from './menu/menu.reducer';
import { MenuEffects } from './menu/menu.effects';
import { AppState } from './app/app.state';
import { appReducer } from './app/app.reducer';
import { AppEffects } from './app/app.effects';
import { StudentState } from './student/student.state';
import { studentReducer } from './student/student.reducer';
import { StudentEffects } from './student/student.effects';
import { EmployeeState } from './employee/employee.state';
import { employeeReducer } from './employee/employee.reducer';
import { EmployeeEffects } from './employee/employee.effects';
import { logoutReducer } from './meta-reducers/logout.reducer';
import { appFailureReducer } from './meta-reducers/app-failure.reducer';

export interface State {
    menu: MenuState;
    app: AppState;
    student: StudentState;
    employee: EmployeeState;
}

export const CoreReducers: ActionReducerMap<State> = {
    menu: menuReducer,
    app: appReducer,
    student: studentReducer,
    employee: employeeReducer,
}

export const MetaReducers: MetaReducer<any>[] = [
    logoutReducer,
    appFailureReducer,
];

export const CoreEffects = [
    MenuEffects,
    AppEffects,
    StudentEffects,
    EmployeeEffects,
]