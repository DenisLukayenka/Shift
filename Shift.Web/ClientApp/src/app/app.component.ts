import { Component, OnInit, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { AppState, selectAppLoading } from './core/store/app/app.state';
import { Subscription } from 'rxjs';
import { LoadApp } from './core/store/app/app.actions';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.scss'],
})
export class AppComponent {
	title = 'app';
}
