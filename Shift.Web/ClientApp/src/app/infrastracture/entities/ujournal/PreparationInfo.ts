import { ResearchWork } from "./ResearchWork";

export class PreparationInfo {
    PreparationInfoId: number;
    Topic: string;
    Relevance: string;
    Objectives: string;
    ResearchProcedure: string;
    Additions: string;
    PreparationAdviser: string;
    ResearchAdviser: string;
    UndergraduateJournalId: number;

    PreparationSubmittedDate?: Date;
    PreparationApprovedDate?: Date;
    IsPreparationSubmitted: boolean;
    IsPreparationApproved: boolean;

    ReseachSubmittedDate: Date;
    ReseachApprovedDate: Date;
    IsResearchSubmitted: boolean;
    IsResearchApproved: boolean;

    ResearchWorks: ResearchWork[];
}