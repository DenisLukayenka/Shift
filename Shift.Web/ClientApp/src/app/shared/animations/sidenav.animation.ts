import { trigger, state, style, transition, animate, keyframes } from "@angular/animations";

const minSidenavWidth = '64px';
const fullSidenavWidth = '240px';
const menuItemWidth = '196px';
const menuItemPadding = '16px';

export const onSideNavChange = trigger('onSideNavChange', [
    state('close',
      style({
        'min-width': minSidenavWidth
      })
    ),
    state('open',
      style({
        'min-width': fullSidenavWidth
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
      'padding-right': '0px',
    })
  ),
  state('open',
    style({
      'max-width': menuItemWidth,
      'width': menuItemWidth,
      'padding-right': menuItemPadding,
    })
  ),
  transition('close => open', animate('400ms ease-in')),
  transition('open => close', animate('400ms ease-out')),
]);

export const animateText = trigger('animateText', [
    state('hide',
      style({
        'opacity': 0,
        'display': 'none',
      })
    ),
    state('show',
      style({
        'display': 'block',
        'opacity': 1,
      })
    ),
    transition('hide => show', animate('400ms ease-in')),
    transition('show => hide', animate('400ms ease-in')),
]);