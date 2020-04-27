import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { ToolbarComponent } from "./core/components/toolbar/toolbar.component";
import { LoginComponent } from "./core/components/login/login.component";
import { RootViewComponent } from "./core/components/root-view/root-view.component";
import { AuthGuard } from "./infrastracture/guards/AuthGuard";

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
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}