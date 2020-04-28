import { NgModule } from "@angular/core";
import { MaterialModule } from "src/app/material/material.module";
import { ToolbarComponent } from "./components/toolbar/toolbar.component";
import { CoreStoreModule } from "./store/core-store.module";
import { SharedModule } from "../shared/SharedModule";
import { RootViewComponent } from "./components/root-view/root-view.component";
import { RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { LoginComponent } from "./components/login/login.component";
import { ViewModule } from "../view/view.module";
import { URegisterComponent } from "./components/register/u-register/u-register.component";
import { RegisterComponent } from "./components/register/register.component";
import { GRegisterComponent } from "./components/register/g-register/g-register.component";
import { ERegisterComponent } from "./components/register/e-register/e-register.component";

@NgModule({
    declarations: [
        ToolbarComponent,
        RootViewComponent,
        LoginComponent,
        
        URegisterComponent,
        RegisterComponent,
        ERegisterComponent,
        GRegisterComponent,
    ],
    imports: [
        CoreStoreModule,
        MaterialModule,
        SharedModule,
        RouterModule,
        FormsModule,
        ViewModule,
        ReactiveFormsModule,
    ],
    exports: [
        RootViewComponent,
    ]
})
export class CoreModule {

}