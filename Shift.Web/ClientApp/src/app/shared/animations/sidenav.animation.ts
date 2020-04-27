import { trigger, state, style, transition, animate } from "@angular/animations";

const minSidenavWidth = '64px';
const fullSidenavWidth = '240px';
const menuItemWidth = '196px';
const menuItemPadding = '5px';

export const onSideNavChange = trigger('onSideNavChange', [
    state('close',
      style({
        'width': minSidenavWidth
      })
    ),
    state('open',
      style({
        'width': fullSidenavWidth
      })
    ),
    transition('close => open', animate('400ms ease-in')),
    transition('open => close', animate('400ms ease-in')),
]);

export const onMainContentChange = trigger('onMainContentChange', [
    state('close',
      style({
        'margin-left': minSidenavWidth
      })
    ),
    state('open',
      style({
        'margin-left': fullSidenavWidth
      })
    ),
    transition('close => open', animate('400ms ease-in')),
    transition('open => close', animate('400ms ease-in')),
]);

export const collapseByWidth = trigger('collapseByWidth', [
  state('close',
    style({
      'max-width': '0px',
      'width': '0px',
    })
  ),
  state('open',
    style({
      'max-width': menuItemWidth,
      'width': menuItemWidth,
    })
  ),
  transition('close => open', animate('400ms ease-in')),
  transition('open => close', animate('400ms ease-out')),
]);