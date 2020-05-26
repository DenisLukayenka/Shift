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
import { UndergraduateComponent } from "./components/undergraduate/undergraduate.component";
import { GraduateComponent } from "./components/graduate/graduate.component";
import { NotFoundComponent } from "./components/not-found/not-found.component";
import { EmployeeComponent } from "./components/employee/employee.component";
import { UndergraduateJournalComponent } from "./components/undergraduate/journal/undergraduate-journal.component";
import { GraduateJournalComponent } from "./components/graduate/graduate-journal/graduate-journal.component";
import { LogoutComponent } from "./components/logout/logout.component";

@NgModule({
    declarations: [
        ToolbarComponent,
        RootViewComponent,
        LoginComponent,
        UndergraduateComponent,
        GraduateComponent,
        URegisterComponent,
        RegisterComponent,
        ERegisterComponent,
        GRegisterComponent,
        NotFoundComponent,
        EmployeeComponent,
        UndergraduateJournalComponent,
        GraduateJournalComponent,
        LogoutComponent,
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
        NotFoundComponent,
    ]
})
export class CoreModule {

}