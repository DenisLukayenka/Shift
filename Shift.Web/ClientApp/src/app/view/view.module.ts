import { NgModule } from "@angular/core";
import { MaterialModule } from "../material/material.module";
import { GraduateJournalComponent } from "./gj-view/gj-view.component";
import { UndergraduateJournalComponent } from "./uj-view/uj-view.component";

@NgModule({
    imports: [MaterialModule],
    declarations: [
        GraduateJournalComponent,
        UndergraduateJournalComponent,
    ],
    exports: []
})
export class ViewModule {}