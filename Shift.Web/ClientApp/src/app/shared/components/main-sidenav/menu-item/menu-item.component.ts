import { Component, Input } from "@angular/core";
import { collapseByWidth } from "src/app/shared/animations/sidenav.animation";
import { MenuState, selectIsOpen } from "src/app/core/store/menu/menu.state";
import { Store, select } from '@ngrx/store';

@Component({
    selector: 'pac-menu-item',
    templateUrl: './menu-item.component.html',
    styleUrls: ['./menu-item.component.scss'],
    animations: [collapseByWidth]
})
export class MenuItemComponent {
    @Input() icon: string;
    @Input() name: string;
    @Input() link: string;
    public isShow: boolean;

    constructor(private menuStore: Store<MenuState>){
        this.menuStore.pipe(select(selectIsOpen)).subscribe(isOpen => {
            setTimeout(() => {
                this.isShow = isOpen;
            }, 0);
        });
    }
}