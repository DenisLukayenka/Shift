import { NgModule } from "@angular/core";
import { MaterialModule } from "../material/material.module";
import { GraduateJournalComponent } from "./gj-view/gj-view.component";
import { UndergraduateJournalComponent } from "./uj-view/uj-view.component";
import { ReactiveFormsModule } from "@angular/forms";
import { UJournalListComponent } from "./uj-list/uj-list.component";
import { GJournalListComponent } from "./gj-list/gj-list.component";

@NgModule({
    imports: [MaterialModule, ReactiveFormsModule],
    declarations: [
        GraduateJournalComponent,
        UndergraduateJournalComponent,
        UJournalListComponent,
        GJournalListComponent,
    ],
    exports: [
        GraduateJournalComponent,
        UndergraduateJournalComponent,
        UJournalListComponent,
        GJournalListComponent,
    ]
})
export class ViewModule {}