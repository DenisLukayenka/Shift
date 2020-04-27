import { NgModule } from "@angular/core";
import { MenuItemComponent } from "./components/main-sidenav/menu-item/menu-item.component";
import { MaterialModule } from "../material/material.module";
import { MainSidenavComponent } from "./components/main-sidenav/main-sidenav.component";
import { MenuGroupComponent } from "./components/main-sidenav/menu-group/menu-group.component";

@NgModule({
    declarations: [MenuItemComponent, MainSidenavComponent, MenuGroupComponent],
    imports: [MaterialModule],
    exports: [MenuItemComponent, MainSidenavComponent],
})
export class SharedModule {}