import { Component, OnInit, ChangeDetectorRef } from "@angular/core";
import { MenuState, selectIsOpen } from "../../store/menu/menu.state";
import { MenuToggle } from "../../store/menu/menu.action";
import { Store, select } from "@ngrx/store";
import { AppState, selectIsAuth, selectAppLoading } from "../../store/app/app.state";
import { LoadApp } from "../../store/app/app.actions";
import { onMainContentChange } from "src/app/shared/animations/sidenav.animation";
import { Observable } from "rxjs";
import { ViewType } from "src/app/infrastracture/entities/ViewType";
import { ActivatedRoute } from "@angular/router";
import * as _ from 'lodash';
import { ViewTypeQueryKey } from "src/app/infrastracture/config";

@Component({
    selector: 'pac-root-view',
    styleUrls: ['./root-view.component.scss'],
    templateUrl: './root-view.component.html',
	animations: [ onMainContentChange ]
})
export class RootViewComponent {
    public isOpened = false;
    public viewType: ViewType;
    public isLoading: boolean = false;

    readonly ViewType: ViewType;

    constructor(private appStore: Store<AppState>, private menuStore: Store<MenuState>, private route: ActivatedRoute) {
        this.menuStore.pipe(select(selectIsOpen)).subscribe(opened => {
            setTimeout(() => {
                this.isOpened = opened;
            }, 0);
        });

        this.route.queryParams.subscribe(params => {
            var viewParam = _.find(params, p => !!p[ViewTypeQueryKey]);
            if(!!viewParam) {
                
            }
        });

        this.appStore.pipe(select(selectAppLoading)).subscribe(appLoading => {
			setTimeout(() => {
				this.isLoading = appLoading;
			}, 0);
		});
    }

    public ngOnInit() {
        this.appStore.dispatch(new LoadApp());
    }

    public onSideNavToggle() {
        this.menuStore.dispatch(new MenuToggle());
    }
}