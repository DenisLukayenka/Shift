import { Component } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { AppState, selectAppLoading } from './core/store/app/app.state';
import { onMainContentChange } from './shared/animations/sidenav.animation';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [onMainContentChange]
})
export class AppComponent {
  title = 'app';
  public isLoading: boolean;

  constructor(private appStore: Store<AppState>) {
    this.appStore.pipe(select(selectAppLoading)).subscribe(appLoading => this.isLoading = appLoading);
  }
}
