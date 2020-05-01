import { Protocol } from "../university/Protocol";

export class Report {
    public Id: number;
    public Date: Date;
    public Result: string;
    public DepartmentHead: string;
    public UndergraduateJournalId?: number;

    public ProtocolId: number;
    public Protocol: Protocol;
}