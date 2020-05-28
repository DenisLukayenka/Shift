import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Injectable } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { CoreModule } from './core/core.module';
import { MaterialModule } from './material/material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/SharedModule';
import { HttpRequestInterceptor } from './services/http-processor/interceptors/http-request-interceptor';
import { JwtModule } from "@auth0/angular-jwt";
import { AuthGuard } from './infrastracture/guards/AuthGuard';
import { Router } from '@angular/router';
import { ErrorPageGuard } from './infrastracture/guards/error-page.guard';
import { getJwtToken } from './infrastracture/utilities/getJwtToken';

@Injectable()
export class WindowWrapper extends Window { }

export function getWindow() { return window; }

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    CoreModule,
    SharedModule,
    BrowserAnimationsModule,
    MaterialModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: getJwtToken,
        whitelistedDomains: ["localhost:4200", "localhost:50280"],
        blacklistedRoutes: []
      }
    }),
  ],
  providers: [
    { provide: WindowWrapper, useValue: getWindow },
    { provide: HTTP_INTERCEPTORS, useClass: HttpRequestInterceptor, multi: true },
    AuthGuard,
    ErrorPageGuard,
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(private router: Router) {}

  ngDoBootstrap() {
    this.router.initialNavigation();
  }
}
