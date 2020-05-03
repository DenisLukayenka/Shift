import { Component, OnInit, OnDestroy, ChangeDetectorRef, AfterContentInit } from "@angular/core";
import { MenuState, selectIsOpen } from "../../store/menu/menu.state";
import { MenuToggle } from "../../store/menu/menu.action";
import { Store, select } from "@ngrx/store";
import { AppState, selectAppLoading, selectDefaultRoute, selectViewLoading } from "../../store/app/app.state";
import { LoadApp } from "../../store/app/app.actions";
import { onMainContentChange } from "src/app/shared/animations/sidenav.animation";
import { Observable, Subscription } from "rxjs";
import { ActivatedRoute, Router } from "@angular/router";
import * as _ from 'lodash';

@Component({
    selector: 'pac-root-view',
    styleUrls: ['./root-view.component.scss'],
    templateUrl: './root-view.component.html',
	animations: [ onMainContentChange ]
})
export class RootViewComponent implements OnInit {
    public isMenuOpened$: Observable<boolean>;
    public isLoadingApp$: Observable<boolean>;
    public isViewLoading: boolean = false;
    public defaultRoute: string;

    constructor(
        private appStore: Store<AppState>, 
        private menuStore: Store<MenuState>,
    ) {
        this.isMenuOpened$ = this.menuStore.pipe(select(selectIsOpen));
        this.isLoadingApp$ = this.appStore.pipe(select(selectAppLoading));
        this.appStore.pipe(select(selectDefaultRoute)).subscribe(result => this.defaultRoute = result);
    }

    public ngOnInit() {
        this.appStore.pipe(select(selectViewLoading)).subscribe(r => setTimeout(() => this.isViewLoading = r));
        this.appStore.dispatch(new LoadApp());
    }

    public onSideNavToggle() {
        this.menuStore.dispatch(new MenuToggle());
    }
}