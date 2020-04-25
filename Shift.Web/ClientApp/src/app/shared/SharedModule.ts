import { NgModule } from "@angular/core";
import { MenuItemComponent } from "./components/menu-item/menu-item.component";
import { MaterialModule } from "../material/material.module";

@NgModule({
    declarations: [MenuItemComponent],
    imports: [MaterialModule],
    exports: [MenuItemComponent],
})
export class SharedModule {}