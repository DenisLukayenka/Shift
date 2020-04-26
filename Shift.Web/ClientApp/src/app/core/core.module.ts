import { NgModule } from "@angular/core";
import { MaterialModule } from "src/app/material/material.module";
import { ToolbarComponent } from "./components/toolbar/toolbar.component";
import { CoreStoreModule } from "./store/core-store.module";
import { SharedModule } from "../shared/SharedModule";
import { RootViewComponent } from "./components/root-view/root-view.component";
import { RouterModule } from "@angular/router";

@NgModule({
    declarations: [
        ToolbarComponent,
        RootViewComponent,
    ],
    imports: [
        CoreStoreModule,
        MaterialModule,
        SharedModule,
        RouterModule,
    ],
    exports: [
        ToolbarComponent,
    ]
})
export class CoreModule {

}