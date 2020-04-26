import { Component } from "@angular/core";
import { MenuToggle } from "../../store/menu/menu.action";
import { Store } from "@ngrx/store";
import { MenuState } from "../../store/menu/menu.state";

@Component({
    selector: 'pac-toolbar',
    styleUrls: ['./toolbar.component.scss'],
    templateUrl: './toolbar.component.html'
})
export class ToolbarComponent {
    constructor(private menuStore: Store<MenuState>) {}

    public onSideNavToggle() {
        this.menuStore.dispatch(new MenuToggle());
    }
}