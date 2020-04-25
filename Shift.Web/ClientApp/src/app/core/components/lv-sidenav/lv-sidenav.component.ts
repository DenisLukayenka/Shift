import { Component } from "@angular/core";
import { Store, select } from '@ngrx/store';
import { onSideNavChange, animateText } from "../../animations/sidenav.animation";
import { MenuState, selectIsOpen } from "../../store/menu/menu.state";
import { MenuToggle } from "../../store/menu/menu.action";

@Component({
    selector: 'pac-lv-sidenav',
    styleUrls: ['./lv-sidenav.component.scss'],
    templateUrl: './lv-sidenav.component.html',
    animations: [ onSideNavChange, animateText ]
})
export class LeftViewSidenavComponent {
    public sideNavState: boolean;
    public linkText: boolean = true;

    constructor(private menuStore: Store<MenuState>) {
        this.menuStore.pipe(select(selectIsOpen)).subscribe(isOpen => {
            this.sideNavState = isOpen;
            setTimeout(() => {
                this.linkText = this.sideNavState;
            }, 150);
        }) 
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