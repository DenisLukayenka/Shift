import { Component, Input, OnChanges } from "@angular/core";
import { animateText } from "src/app/shared/animations/sidenav.animation";
import { SimpleChanges } from "@angular/core";
import { MenuState, selectIsOpen } from "src/app/core/store/menu/menu.state";
import { Store, select } from '@ngrx/store';

@Component({
    selector: 'pac-menu-item',
    templateUrl: './menu-item.component.html',
    styleUrls: ['./menu-item.component.scss'],
    animations: [animateText]
})
export class MenuItemComponent {
    @Input() icon: string;
    @Input() name: string;
    @Input() link: string;
    public isShow: boolean = true;

    constructor(private menuStore: Store<MenuState>){
        this.menuStore.pipe(select(selectIsOpen)).subscribe(isOpen => {
            setTimeout(() => {
                this.isShow = isOpen;
            }, 150);
        });
    }
}