import { NgModule } from "@angular/core";
import { LeftViewSidenavComponent } from "./components/lv-sidenav/lv-sidenav.component";
import { MaterialModule } from "src/app/material/material.module";
import { ToolbarComponent } from "./components/toolbar/toolbar.component";
import { CoreStoreModule } from "./store/core-store.module";
import { AsyncPipe } from "@angular/common";

@NgModule({
    declarations: [
        LeftViewSidenavComponent,
        ToolbarComponent,
    ],
    imports: [
        CoreStoreModule,
        MaterialModule,
    ],
    exports: [
        LeftViewSidenavComponent,
        ToolbarComponent,
    ]
})
export class CoreModule {

}