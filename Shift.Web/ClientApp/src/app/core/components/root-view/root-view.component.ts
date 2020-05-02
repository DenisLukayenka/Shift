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
import { ViewTypeQueryParam } from "src/app/infrastracture/config";
import { ViewType } from "src/app/infrastracture/entities/ViewType";

@Component({
    selector: 'pac-root-view',
    styleUrls: ['./root-view.component.scss'],
    templateUrl: './root-view.component.html',
	animations: [ onMainContentChange ]
})
export class RootViewComponent implements OnInit, OnDestroy, AfterContentInit {
    public isMenuOpened$: Observable<boolean>;
    public currentViewType: string;
    public isLoadingApp$: Observable<boolean>;
    public isViewLoading: boolean = false;
    public defaultRoute: string;

    viewTypes = ViewType;
    private onRouteChange: Subscription;

    constructor(
        private appStore: Store<AppState>, 
        private menuStore: Store<MenuState>, 
        private route: ActivatedRoute, 
        private router: Router,
        private cd: ChangeDetectorRef
    ) {
        this.isMenuOpened$ = this.menuStore.pipe(select(selectIsOpen));
        this.isLoadingApp$ = this.appStore.pipe(select(selectAppLoading));
        this.appStore.pipe(select(selectDefaultRoute)).subscribe(result => this.defaultRoute = result);
    }

    public ngOnInit() {
        this.appStore.pipe(select(selectViewLoading)).subscribe(r => setTimeout(() => this.isViewLoading = r));
        this.appStore.dispatch(new LoadApp());

        this.onRouteChange = this.route.queryParams.subscribe((params) => {
            var viewParam = params[ViewTypeQueryParam];
            if(!!viewParam) {
                this.currentViewType = viewParam;
            } else {
                this.router.navigate([], {
                    queryParams: { [ViewTypeQueryParam]: this.defaultRoute }
                });
            }
        });
    }

    ngAfterContentInit (): void {
        this.cd.detectChanges();
    }

    public ngOnDestroy() {
        this.onRouteChange.unsubscribe();
    }

    public onSideNavToggle() {
        this.menuStore.dispatch(new MenuToggle());
    }
}