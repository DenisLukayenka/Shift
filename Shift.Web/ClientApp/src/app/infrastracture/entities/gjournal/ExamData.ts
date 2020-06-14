import { Discipline } from "../university/Discipline";

export class ExamData {
    Id: number;
    Mark: number;
    Date: Date;
    DisciplineId: number;
    Discipline: Discipline;
    GraduateJournalId: number;
}