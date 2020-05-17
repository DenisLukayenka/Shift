import { UserContext } from "./UserContext";
import { UJournal } from "../ujournal/UJournal";

export class UndergraduateContext extends UserContext {
    public JournalId: number;
    public Journal: UJournal;
}