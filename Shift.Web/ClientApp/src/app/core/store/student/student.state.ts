import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UJournal } from "src/app/infrastracture/entities/ujournal/UJournal";
import { GJournal } from "src/app/infrastracture/entities/gjournal/GJournal";

export interface StudentState {
    uJournal: UJournal;
    gJournal: GJournal;
}

export const initialState: StudentState = {
    uJournal: null,
    gJournal: null,
}

export const selectStudentState = createFeatureSelector<StudentState>('student');
export const selectUJournal = createSelector(selectStudentState, state => state.uJournal);
export const selectGJournal = createSelector(selectStudentState, state => state.gJournal);