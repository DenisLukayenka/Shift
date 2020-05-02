import { Action } from '@ngrx/store';
import { UJournal } from 'src/app/infrastracture/entities/ujournal/UJournal';

export enum StudentActionTypes {
    LoadUJournal = '[Pac] Load UJournal',
    LoadUJournalSuccess = '[Pac] Load UJournal Success',

    SaveUJournal = '[Pac] Save UJournal',
    SaveUJournalSuccess = '[Pac] Save UJournal Success',
}

export class LoadUJournal implements Action {
    readonly type = StudentActionTypes.LoadUJournal;

    constructor(public payload: { userId: number }){}
};

export class LoadUJournalSuccess implements Action {
    readonly type = StudentActionTypes.LoadUJournalSuccess;

    constructor(public payload: { journal: UJournal }){}
};

export class SaveUJournal implements Action {
    readonly type = StudentActionTypes.SaveUJournal;

    constructor(public payload: { journal: UJournal }){}
};

export class SaveUJournalSuccess implements Action {
    readonly type = StudentActionTypes.SaveUJournalSuccess;

    constructor(public payload: { message: string }){}
};

export type StudentActionsUnion = 
    | LoadUJournal
    | LoadUJournalSuccess
    
    | SaveUJournal
    | SaveUJournalSuccess;