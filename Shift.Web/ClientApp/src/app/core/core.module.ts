import { NgModule } from "@angular/core";
import { MaterialModule } from "src/app/material/material.module";
import { ToolbarComponent } from "./components/toolbar/toolbar.component";
import { CoreStoreModule } from "./store/core-store.module";
import { SharedModule } from "../shared/SharedModule";
import { RootViewComponent } from "./components/root-view/root-view.component";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { LoginComponent } from "./components/login/login.component";
import { ViewModule } from "../view/view.module";

@NgModule({
    declarations: [
        ToolbarComponent,
        RootViewComponent,
        LoginComponent,
    ],
    imports: [
        CoreStoreModule,
        MaterialModule,
        SharedModule,
        RouterModule,
        FormsModule,
        ViewModule,
    ],
    exports: [
        RootViewComponent,
    ]
})
export class CoreModule {

}