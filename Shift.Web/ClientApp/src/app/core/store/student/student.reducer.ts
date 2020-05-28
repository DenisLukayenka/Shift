import { StudentState, initialState } from "./student.state";
import { StudentActionsUnion, StudentActionTypes } from "./student.actions";
import { produce } from 'immer';

export function studentReducer(state = initialState, action: StudentActionsUnion): StudentState {
    switch (action.type) {
        case StudentActionTypes.LoadUJournalSuccess:
            return produce(state, draft => {
                draft.uJournal = action.payload.journal;
            });
        case StudentActionTypes.LoadGJournalSuccess:
            return produce(state, draft => {
                draft.gJournal = action.payload.journal;
            });
        case StudentActionTypes.SaveUJournalSuccess:
            return produce(state, draft => {
                draft.uJournal = action.payload.journal;
            });
        case StudentActionTypes.SaveGJournalSuccess:
            return produce(state, draft => {
                draft.gJournal = action.payload.journal;
            });
        case StudentActionTypes.ResetJournals:
            return produce(state, draft => {
                draft.uJournal = initialState.uJournal;
                draft.gJournal = initialState.gJournal;
            })
        default:
            return state;
    }
}