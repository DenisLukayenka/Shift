import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { StoreRouterConnectingModule } from '@ngrx/router-store';
import { CoreReducers, CoreEffects, MetaReducers } from './state';
import { environment } from 'src/environments/environment';

@NgModule({
    imports: [
        StoreModule.forRoot(CoreReducers, { metaReducers: MetaReducers }),
        EffectsModule.forRoot(CoreEffects),
        StoreDevtoolsModule.instrument({
            maxAge: 25,
        }),
        StoreRouterConnectingModule.forRoot({ stateKey: 'router' }),
        !environment.production ? StoreDevtoolsModule.instrument(): [],
    ],
})
export class CoreStoreModule {}