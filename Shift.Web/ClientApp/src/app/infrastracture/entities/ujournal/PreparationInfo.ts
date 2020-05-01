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
    PreparationSubmittedDate?: Date;
    PreparationApprovedDate?: Date;
    IsPreparationSubmitted: boolean;
    IsPreparationApproved: boolean;
    IsResearchSubmitted: boolean;
    IsResearchApproved: boolean;
    UndergraduateJournalId: number;

    ResearchWorks: ResearchWork[];
}