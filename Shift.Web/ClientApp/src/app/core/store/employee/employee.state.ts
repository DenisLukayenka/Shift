import { GraduateContext } from "src/app/infrastracture/entities/users/GraduateContext";
import { UndergraduateContext } from "src/app/infrastracture/entities/users/UndergraduateContext";
import { createFeatureSelector, createSelector } from "@ngrx/store";

export interface EmployeeState {
    Graduates: GraduateContext[];
    Undergraduates: UndergraduateContext[];
}

export const initialState: EmployeeState = {
    Graduates: [],
    Undergraduates: [],
}

export const selectEmployee = createFeatureSelector<EmployeeState>('employee');
export const selectUndergraduates = createSelector(selectEmployee, state => state.Undergraduates);
export const selectGraduates = createSelector(selectEmployee, state => state.Graduates);