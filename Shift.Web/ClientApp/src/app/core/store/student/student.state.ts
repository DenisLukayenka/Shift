import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UJournal } from "src/app/infrastracture/entities/ujournal/UJournal";

export interface StudentState {
    uJournal: UJournal;
}

export const initialState: StudentState = {
    uJournal: undefined,
}

export const selectStudentState = createFeatureSelector<StudentState>('student');
export const selectUJournal = createSelector(selectStudentState, state => state.uJournal);