import { NgModule } from "@angular/core";
import { MaterialModule } from "../material/material.module";
import { GJViewComponent } from "./gj-view/gj-view.component";
import { UJViewComponent } from "./uj-view/uj-view.component";
import { ReactiveFormsModule } from "@angular/forms";
import { UJournalListComponent } from "./uj-list/uj-list.component";
import { GJournalListComponent } from "./gj-list/gj-list.component";

@NgModule({
    imports: [MaterialModule, ReactiveFormsModule],
    declarations: [
        GJViewComponent,
        UJViewComponent,
        UJournalListComponent,
        GJournalListComponent,
    ],
    exports: [
        GJViewComponent,
        UJViewComponent,
        UJournalListComponent,
        GJournalListComponent,
    ]
})
export class ViewModule {}