import { NgModule } from "@angular/core";
import { MaterialModule } from "../material/material.module";
import { GraduateJournalComponent } from "./gj-view/gj-view.component";
import { UndergraduateJournalComponent } from "./uj-view/uj-view.component";
import { ReactiveFormsModule } from "@angular/forms";

@NgModule({
    imports: [MaterialModule, ReactiveFormsModule],
    declarations: [
        GraduateJournalComponent,
        UndergraduateJournalComponent,
    ],
    exports: [
        GraduateJournalComponent,
        UndergraduateJournalComponent,
    ]
})
export class ViewModule {}