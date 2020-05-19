import { NgModule } from "@angular/core";
import { MenuItemComponent } from "./components/main-sidenav/menu-item/menu-item.component";
import { MaterialModule } from "../material/material.module";
import { MainSidenavComponent } from "./components/main-sidenav/main-sidenav.component";
import { MenuGroupComponent } from "./components/main-sidenav/menu-group/menu-group.component";
import { ErrorPageComponent } from "./components/error-page/error-page.component";
import { StudentsListComponent } from "./components/students-list/students-list.component";
import { UserRegisterComponent } from "./components/user-register/user-register.component";
import { LoginRegisterComponent } from "./components/login-register/login-register.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

@NgModule({
    declarations: [
        MenuItemComponent, 
        MainSidenavComponent, 
        MenuGroupComponent,
        ErrorPageComponent,
        StudentsListComponent,
        UserRegisterComponent,
        LoginRegisterComponent,
    ],
    imports: [MaterialModule, FormsModule, ReactiveFormsModule],
    exports: [
        ErrorPageComponent,
        MainSidenavComponent,
        StudentsListComponent,
        UserRegisterComponent,
        LoginRegisterComponent,
    ],
})
export class SharedModule {}