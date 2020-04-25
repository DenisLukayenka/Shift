import { trigger, state, style, transition, animate } from "@angular/animations";

const minSidenavWidth = '64px';
const fullSidenavWidth = '240px';

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
    transition('close => open', animate('250ms ease-in')),
    transition('open => close', animate('250ms ease-in')),
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
    transition('close => open', animate('250ms ease-in')),
    transition('open => close', animate('250ms ease-in')),
]);

export const animateText = trigger('animateText', [
    state('hide',
      style({
        'display': 'none',
        opacity: 0,
      })
    ),
    state('show',
      style({
        'display': 'block',
        opacity: 1,
      })
    ),
    transition('close => open', animate('200ms ease-in')),
    transition('open => close', animate('200ms ease-out')),
]);