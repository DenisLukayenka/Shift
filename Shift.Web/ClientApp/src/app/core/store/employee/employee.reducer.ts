import { initialState, EmployeeState } from "./employee.state";
import { EmployeeActionsUnion, EmployeeActionTypes } from "./employee.action";
import produce from "immer";

export function employeeReducer(state = initialState, action: EmployeeActionsUnion): EmployeeState {
    switch(action.type) {
        case EmployeeActionTypes.LoadGraduatesSuccess:
            return produce(state, draft => {
                draft.Graduates = action.payload.graduates;
            });
        case EmployeeActionTypes.LoadUndergraduatesSuccess:
            return produce(state, draft => {
                draft.Undergraduates = action.payload.undergraduates;
            });
        default: 
            return state;
    }
}