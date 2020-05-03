import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { LoginComponent } from "./core/components/login/login.component";
import { RootViewComponent } from "./core/components/root-view/root-view.component";
import { AuthGuard } from "./infrastracture/guards/AuthGuard";
import { ErrorPageComponent } from "./shared/components/error-page/error-page.component";
import { ErrorPageGuard } from "./infrastracture/guards/error-page.guard";
import { RegisterPage, LoginPage, RootPage, ErrorPage, UndergraduatePage, GraduatePage, UJournalPage, GJournalPage } from "./infrastracture/config";
import { RegisterComponent } from "./core/components/register/register.component";
import { UndergraduateComponent } from "./core/components/undergraduate/undergraduate.component";
import { GraduateComponent } from "./core/components/graduate/graduate.component";
import { NotFoundComponent } from "./core/components/not-found/not-found.component";
import { UndergraduateJournalComponent } from "./view/uj-view/uj-view.component";
import { GraduateJournalComponent } from "./view/gj-view/gj-view.component";

const routes: Routes = [
    { 
        path: RootPage, 
        component: RootViewComponent,
        runGuardsAndResolvers: 'paramsOrQueryParamsChange',
        canActivate: [AuthGuard],
        children: [
            { path: UndergraduatePage, component: UndergraduateComponent, children: [
                { path: UJournalPage, component: UndergraduateJournalComponent },
            ]},
            { path: GraduatePage, component: GraduateComponent, children: [
                { path: GJournalPage, component: GraduateJournalComponent },
            ]}
        ]
    },

    { path: LoginPage, component: LoginComponent },
    { path: RegisterPage, component: RegisterComponent, runGuardsAndResolvers: 'paramsOrQueryParamsChange' },

    { path: '', redirectTo: RootPage, pathMatch: 'full' },
    { path: ErrorPage, component: ErrorPageComponent, canActivate: [ErrorPageGuard] },
    { path: '**', component: NotFoundComponent },
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}