import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { LoginComponent } from "./core/components/login/login.component";
import { RootViewComponent } from "./core/components/root-view/root-view.component";
import { AuthGuard } from "./infrastracture/guards/AuthGuard";
import { ErrorPageComponent } from "./shared/components/error-page/error-page.component";
import { ErrorPageGuard } from "./infrastracture/guards/error-page.guard";
import { RegisterPage, LoginPage, RootPage, ErrorPage } from "./infrastracture/config";
import { RegisterComponent } from "./core/components/register/register.component";

const routes: Routes = [
    { 
        path: RootPage, 
        component: RootViewComponent,
        runGuardsAndResolvers: 'paramsOrQueryParamsChange',
        canActivate: [AuthGuard],
    },

    { path: LoginPage, component: LoginComponent },
    { path: RegisterPage, component: RegisterComponent, runGuardsAndResolvers: 'paramsOrQueryParamsChange' },

    { path: '', redirectTo: RootPage, pathMatch: 'full' },
    { path: ErrorPage, component: ErrorPageComponent, canActivate: [ErrorPageGuard] }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}