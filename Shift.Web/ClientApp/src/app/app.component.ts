import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { AppState, selectAppLoading } from './core/store/app/app.state';
import { LoadSuccess, LoadApp } from './core/store/app/app.actions';
import { onMainContentChange, onSideNavChange } from './shared/animations/sidenav.animation';
import { MenuState, selectIsOpen } from './core/store/menu/menu.state';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.scss'],
	animations: [ onMainContentChange, onSideNavChange ]
})
export class AppComponent implements OnInit {
	title = 'app';
	public isLoading: boolean;
	public isOpened: boolean;

	constructor(private appStore: Store<AppState>, private menuStore: Store<MenuState>) {
		this.appStore.pipe(select(selectAppLoading)).subscribe(appLoading => this.isLoading = appLoading);
		this.menuStore.pipe(select(selectIsOpen)).subscribe(opened => this.isOpened = opened);
	}

	ngOnInit (): void {
		this.appStore.dispatch(new LoadApp());
	}
}
