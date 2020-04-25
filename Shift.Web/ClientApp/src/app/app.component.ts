import { Component } from '@angular/core';
import { onMainContentChange } from './core/animations/sidenav.animation';
import { MenuState, selectIsOpen } from './core/store/menu/menu.state';
import { Store, select } from '@ngrx/store';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [ onMainContentChange ]
})
export class AppComponent {
  title = 'app';
  public onSideNavChange: boolean;

  constructor(private menuStore: Store<MenuState>) {
    this.menuStore.pipe(select(selectIsOpen)).subscribe(isOpen => this.onSideNavChange = isOpen);
  }
}
