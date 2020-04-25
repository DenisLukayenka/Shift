import { Component } from "@angular/core";
import { Store, select } from '@ngrx/store';
import { onSideNavChange, animateText } from "src/app/shared/animations/sidenav.animation";
import { MenuState, selectIsOpen } from "src/app/core/store/menu/menu.state";
import { MenuToggle } from "src/app/core/store/menu/menu.action";

@Component({
    selector: 'pac-main-sidenav',
    styleUrls: ['./main-sidenav.component.scss'],
    templateUrl: './main-sidenav.component.html',
    animations: [ onSideNavChange, animateText ]
})
export class MainSidenavComponent {
    public sideNavState: boolean;

    constructor(private menuStore: Store<MenuState>) {
        this.menuStore.pipe(select(selectIsOpen)).subscribe(isOpen => this.sideNavState = isOpen) 
    }

    public pages: Page[] = [
        {name: 'Inbox', link:'some-link', icon: 'inbox'},
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