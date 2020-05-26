import { Component } from "@angular/core";
import { MenuToggle } from "../../store/menu/menu.action";
import { Store, select } from "@ngrx/store";
import { MenuState } from "../../store/menu/menu.state";
import { AppState, selectUserContext } from "../../store/app/app.state";
import { LogOut } from "../../store/app/app.actions";
import { UserContext } from "src/app/infrastracture/entities/users/UserContext";

@Component({
    selector: 'pac-toolbar',
    styleUrls: ['./toolbar.component.scss'],
    templateUrl: './toolbar.component.html'
})
export class ToolbarComponent {
    userContext: UserContext;
    
    constructor(private menuStore: Store<MenuState>, private appStore: Store<AppState>) {
        this.appStore.pipe(select(selectUserContext)).subscribe(userContext => this.userContext = userContext);
    }

    public onSideNavToggle() {
        this.menuStore.dispatch(new MenuToggle());
    }

    public logout() {
        this.appStore.dispatch(new LogOut());
    }
}