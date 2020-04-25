import { Component, Input, OnChanges } from "@angular/core";
import { animateText } from "src/app/shared/components/animations/sidenav.animation";
import { SimpleChanges } from "@angular/core";

@Component({
    selector: 'pac-menu-item',
    templateUrl: './menu-item.component.html',
    styleUrls: ['./menu-item.component.scss'],
    animations: [animateText]
})
export class MenuItemComponent implements OnChanges {
    @Input() icon: string;
    @Input() name: string;
    @Input() link: string;
    @Input() isShow: boolean = true;

    public ngOnChanges(changes: SimpleChanges ): void {
        if(!!changes.isShow.currentValue) {
            this.isShow = changes.isShow.currentValue;
        }
    }
}