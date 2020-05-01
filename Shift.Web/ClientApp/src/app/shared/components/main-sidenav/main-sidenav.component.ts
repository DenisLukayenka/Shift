import { Component } from "@angular/core";
import { Store, select } from '@ngrx/store';
import { onSideNavChange } from "src/app/shared/animations/sidenav.animation";
import { MenuState, selectIsOpen, selectRootMenu } from "src/app/core/store/menu/menu.state";
import { RootMenu } from "src/app/infrastracture/entities/menu/RootMenu";
import { Observable } from "rxjs";

@Component({
    selector: 'pac-main-sidenav',
    styleUrls: ['./main-sidenav.component.scss'],
    templateUrl: './main-sidenav.component.html',
    animations: [ onSideNavChange ]
})
export class MainSidenavComponent {
    public isShow: boolean;
    public menu$: Observable<RootMenu>;

    constructor(private menuStore: Store<MenuState>) {
        this.menuStore.pipe(select(selectIsOpen)).subscribe(isOpen => {
            setTimeout(() => {
                this.isShow = isOpen;
            }, 0);
        });
        this.menu$ = this.menuStore.pipe(select(selectRootMenu));
    }
}