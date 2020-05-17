import { Component, Input } from "@angular/core";
import { MenuGroup } from "src/app/infrastracture/entities/menu/MenuGroup";

@Component({
    selector: 'pac-menu-group',
    styleUrls: ['./menu-group.component.scss'],
    templateUrl: './menu-group.component.html',
})
export class MenuGroupComponent {
    @Input() menuGroup: MenuGroup;
    @Input() isMenuOpen: boolean;
}