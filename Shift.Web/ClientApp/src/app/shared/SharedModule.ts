import { NgModule } from "@angular/core";
import { MenuItemComponent } from "./components/menu-item/menu-item.component";
import { MaterialModule } from "../material/material.module";
import { MainSidenavComponent } from "./components/main-sidenav/main-sidenav.component";

@NgModule({
    declarations: [MenuItemComponent, MainSidenavComponent],
    imports: [MaterialModule],
    exports: [MenuItemComponent, MainSidenavComponent],
})
export class SharedModule {}