import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { ToolbarComponent } from "./core/components/toolbar/toolbar.component";
import { LoginComponent } from "./core/components/login/login.component";
import { RootViewComponent } from "./core/components/root-view/root-view.component";
import { AuthGuard } from "./infrastracture/guards/AuthGuard";
import { ErrorPageComponent } from "./shared/components/error-page/error-page.component";
import { ErrorPageGuard } from "./infrastracture/guards/error-page.guard";

const routes: Routes = [
    { 
        path: 'root', 
        component: RootViewComponent,
        runGuardsAndResolvers: 'paramsOrQueryParamsChange',
        canActivate: [AuthGuard],
    },

    { path: 'login', component: LoginComponent },
    { path: 'toolbar', component: ToolbarComponent },

    { path: '', redirectTo: '/root', pathMatch: 'full' },
    { path: 'error', component: ErrorPageComponent, canActivate: [ErrorPageGuard] }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}