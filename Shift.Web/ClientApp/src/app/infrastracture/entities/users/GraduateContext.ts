import { UserContext } from "./UserContext";
import { GJournal } from "../gjournal/GJournal";

export class GraduateContext extends UserContext {
    public JournalId: number;
    public Journal: GJournal;
}