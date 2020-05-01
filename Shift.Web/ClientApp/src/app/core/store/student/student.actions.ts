import { Action } from '@ngrx/store';
import { UJournal } from 'src/app/infrastracture/entities/ujournal/UJournal';

export enum StudentActionTypes {
    LoadUJournal = '[Pac] Load UJournal',
    LoadUJournalSuccess = '[Pac] Load UJournal Success',
}

export class LoadUJournal implements Action {
    readonly type = StudentActionTypes.LoadUJournal;

    constructor(public payload: { userId: number }){}
};

export class LoadUJournalSuccess implements Action {
    readonly type = StudentActionTypes.LoadUJournalSuccess;

    constructor(public payload: { journal: UJournal }){}
};

export type StudentActionsUnion = 
    | LoadUJournal
    | LoadUJournalSuccess;