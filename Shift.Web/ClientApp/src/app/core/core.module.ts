import { NgModule } from "@angular/core";
import { LeftViewSidenavComponent } from "./components/lv-sidenav/lv-sidenav.component";
import { MaterialModule } from "src/app/material/material.module";
import { ToolbarComponent } from "./components/toolbar/toolbar.component";
import { CoreStoreModule } from "./store/core-store.module";
import { SharedModule } from "../shared/SharedModule";

@NgModule({
    declarations: [
        LeftViewSidenavComponent,
        ToolbarComponent,
    ],
    imports: [
        CoreStoreModule,
        MaterialModule,
        SharedModule,
    ],
    exports: [
        LeftViewSidenavComponent,
        ToolbarComponent,
    ]
})
export class CoreModule {

}