import { Component } from "@angular/core";
import { MenuState, selectIsOpen } from "../../store/menu/menu.state";
import { MenuToggle } from "../../store/menu/menu.action";
import { Store, select } from "@ngrx/store";

@Component({
    selector: 'pac-root-view',
    styleUrls: ['./root-view.component.scss'],
    templateUrl: './root-view.component.html',
})
export class RootViewComponent {
    constructor(private menuStore: Store<MenuState>) {}

    public pages: Page[] = [
        {name: 'Inbox', link:'/toolbar', icon: 'inbox'},
        {name: 'Starred', link:'some-link', icon: 'star'},
        {name: 'Send email', link:'some-link', icon: 'send'},
    ]

    public onSideNavToggle() {
        this.menuStore.dispatch(new MenuToggle());
    }
}

interface Page {
    link: string;
    name: string;
    icon: string;
}