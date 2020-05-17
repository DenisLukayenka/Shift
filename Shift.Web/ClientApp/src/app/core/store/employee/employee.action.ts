import { Action } from '@ngrx/store';
import { UndergraduateContext } from 'src/app/infrastracture/entities/users/UndergraduateContext';
import { GraduateContext } from 'src/app/infrastracture/entities/users/GraduateContext';
import { GJournal } from 'src/app/infrastracture/entities/gjournal/GJournal';
import { UJournal } from 'src/app/infrastracture/entities/ujournal/UJournal';

export enum EmployeeActionTypes {
    LoadUndergraduates = '[Pac] Load Undergraduates',
    LoadGraduates = '[Pac] Load Graduates',
    LoadUndergraduatesSuccess = '[Pac] Load Undergraduates Success',
    LoadGraduatesSuccess = '[Pac] Load Graduates Success',

    LoadGraduateJournal = '[Pac] Load Graduate Journal',
    LoadUndergraduateJournal = '[Pac] Load Undergraduate Journal',
    LoadGraduateJournalSuccess = '[Pac] Load Graduate Journal Success',
    LoadUndergraduateJournalSuccess = '[Pac] Load Undergraduate Journal Success',
}

export class LoadUndergraduates implements Action {
    readonly type = EmployeeActionTypes.LoadUndergraduates;

    constructor(public payload: { employeeId: number }) {}
};
export class LoadGraduates implements Action {
    readonly type = EmployeeActionTypes.LoadGraduates;

    constructor(public payload: { employeeId: number }) {}
};

export class LoadUndergraduatesSuccess implements Action {
    readonly type = EmployeeActionTypes.LoadUndergraduatesSuccess;

    constructor(public payload: { undergraduates: UndergraduateContext[] }) {}
};
export class LoadGraduatesSuccess implements Action {
    readonly type = EmployeeActionTypes.LoadGraduatesSuccess;

    constructor(public payload: { graduates: GraduateContext[] }) {}
};

export class LoadGraduateJournal implements Action {
    readonly type = EmployeeActionTypes.LoadGraduateJournal;

    constructor(public payload: { journalId: number }) {}
};
export class LoadUndergraduateJournal implements Action {
    readonly type = EmployeeActionTypes.LoadUndergraduateJournal;

    constructor(public payload: { journalId: number }) {}
};

export class LoadGraduateJournalSuccess implements Action {
    readonly type = EmployeeActionTypes.LoadGraduateJournalSuccess;

    constructor(public payload: { journal: GJournal }) {}
};

export class LoadUndergraduateJournalSuccess implements Action {
    readonly type = EmployeeActionTypes.LoadUndergraduateJournalSuccess;

    constructor(public payload: { journal: UJournal }) {}
};

export type EmployeeActionsUnion = 
    | LoadUndergraduates
    | LoadGraduates
    | LoadUndergraduatesSuccess
    | LoadGraduatesSuccess

    | LoadGraduateJournal
    | LoadUndergraduateJournal
    | LoadGraduateJournalSuccess
    | LoadUndergraduateJournalSuccess;