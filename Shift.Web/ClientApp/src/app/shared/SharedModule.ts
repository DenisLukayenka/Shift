import { NgModule } from "@angular/core";
import { MenuItemComponent } from "./components/main-sidenav/menu-item/menu-item.component";
import { MaterialModule } from "../material/material.module";
import { MainSidenavComponent } from "./components/main-sidenav/main-sidenav.component";
import { MenuGroupComponent } from "./components/main-sidenav/menu-group/menu-group.component";
import { ErrorPageComponent } from "./components/error-page/error-page.component";
import { StudentsListComponent } from "./components/students-list/students-list.component";

@NgModule({
    declarations: [
        MenuItemComponent, 
        MainSidenavComponent, 
        MenuGroupComponent,
        ErrorPageComponent,
        StudentsListComponent,
    ],
    imports: [MaterialModule],
    exports: [
        ErrorPageComponent,
        MainSidenavComponent,
        StudentsListComponent,
    ],
})
export class SharedModule {}