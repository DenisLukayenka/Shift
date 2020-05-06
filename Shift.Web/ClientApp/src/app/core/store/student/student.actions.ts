import { Action } from '@ngrx/store';
import { UJournal } from 'src/app/infrastracture/entities/ujournal/UJournal';
import { GJournal } from 'src/app/infrastracture/entities/gjournal/GJournal';

export enum StudentActionTypes {
    LoadUJournal = '[Pac] Load UJournal',
    LoadUJournalSuccess = '[Pac] Load UJournal Success',
    ExecuteLoadUJournal = '[Pac] Execute Load UJournal',

    LoadGJournal = '[Pac] Load GJournal',
    LoadGJournalSuccess = '[Pac] Load GJournal Success',
    ExecuteLoadGJournal = '[Pac] Execute Load GJournal',

    SaveUJournal = '[Pac] Save UJournal',
    SaveUJournalSuccess = '[Pac] Save UJournal Success',

    SaveGJournal = '[Pac] Save GJournal',
    SaveGJournalSuccess = '[Pac] Save GJournal Success',
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

    constructor(public payload: { journal: UJournal }){}
};

export class LoadGJournal implements Action {
    readonly type = StudentActionTypes.LoadGJournal;

    constructor(public payload: { userId: number }){}
};

export class LoadGJournalSuccess implements Action {
    readonly type = StudentActionTypes.LoadGJournalSuccess;

    constructor(public payload: { journal: GJournal }){}
};

export class SaveGJournal implements Action {
    readonly type = StudentActionTypes.SaveGJournal;

    constructor(public payload: { journal: GJournal }){}
};

export class SaveGJournalSuccess implements Action {
    readonly type = StudentActionTypes.SaveGJournalSuccess;

    constructor(public payload: { journal: GJournal }){}
};

export class ExecuteLoadUJournal implements Action {
    readonly type = StudentActionTypes.ExecuteLoadUJournal;

    constructor(public payload: { userId: number }){}
};

export class ExecuteLoadGJournal implements Action {
    readonly type = StudentActionTypes.ExecuteLoadGJournal;

    constructor(public payload: { userId: number }){}
};

export type StudentActionsUnion = 
    | LoadUJournal
    | LoadUJournalSuccess
    
    | SaveUJournal
    | SaveUJournalSuccess

    | LoadGJournal
    | LoadGJournalSuccess
    
    | SaveGJournal
    | SaveGJournalSuccess
    | ExecuteLoadUJournal
    | ExecuteLoadGJournal;