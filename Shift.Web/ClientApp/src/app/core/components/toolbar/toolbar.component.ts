import { Component } from "@angular/core";
import { MenuToggle } from "../../store/menu/menu.action";
import { Store } from "@ngrx/store";
import { MenuState } from "../../store/menu/menu.state";
import { AppState } from "../../store/app/app.state";
import { LogOut } from "../../store/app/app.actions";

@Component({
    selector: 'pac-toolbar',
    styleUrls: ['./toolbar.component.scss'],
    templateUrl: './toolbar.component.html'
})
export class ToolbarComponent {
    constructor(private menuStore: Store<MenuState>, private appStore: Store<AppState>) {}

    public onSideNavToggle() {
        this.menuStore.dispatch(new MenuToggle());
    }

    public logout() {
        this.appStore.dispatch(new LogOut());
    }
}