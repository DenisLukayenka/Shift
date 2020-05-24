import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { LoginComponent } from "./core/components/login/login.component";
import { RootViewComponent } from "./core/components/root-view/root-view.component";
import { AuthGuard } from "./infrastracture/guards/AuthGuard";
import { ErrorPageComponent } from "./shared/components/error-page/error-page.component";
import { ErrorPageGuard } from "./infrastracture/guards/error-page.guard";
import * as Config from "./infrastracture/config";
import { RegisterComponent } from "./core/components/register/register.component";
import { UndergraduateComponent } from "./core/components/undergraduate/undergraduate.component";
import { GraduateComponent } from "./core/components/graduate/graduate.component";
import { NotFoundComponent } from "./core/components/not-found/not-found.component";
import { EmployeeComponent } from "./core/components/employee/employee.component";
import { UJournalListComponent } from "./view/uj-list/uj-list.component";
import { GJournalListComponent } from "./view/gj-list/gj-list.component";
import { UndergraduateJournalComponent } from "./core/components/undergraduate/journal/undergraduate-journal.component";
import { GraduateJournalComponent } from "./core/components/graduate/graduate-journal/graduate-journal.component";

const routes: Routes = [
    { 
        path: Config.RootPage, 
        component: RootViewComponent,
        runGuardsAndResolvers: 'paramsOrQueryParamsChange',
        canActivate: [AuthGuard],
        children: [
            { path: Config.UndergraduatePage, redirectTo: `${Config.UndergraduatePage}/${Config.UJournalPage}` },
            { path: Config.UndergraduatePage, component: UndergraduateComponent, children: [
                { path: Config.UJournalPage, component: UndergraduateJournalComponent },
            ]},

            { path: Config.GraduatePage, redirectTo: `${Config.GraduatePage}/${Config.GJournalPage}` },
            { path: Config.GraduatePage, component: GraduateComponent, children: [
                { path: Config.GJournalPage, component: GraduateJournalComponent },
            ]},

            { path: Config.EmployeePage, redirectTo: `${Config.EmployeePage}/${Config.UJournalList}`},
            { path: Config.EmployeePage, component: EmployeeComponent, children: [
                { path: Config.UJournalList, component: UJournalListComponent },
                { path: Config.GJournalList, component: GJournalListComponent}
            ]},
        ]
    },

    { path: Config.LoginPage, component: LoginComponent },
    { path: Config.RegisterPage, component: RegisterComponent },

    { path: '', redirectTo: Config.RootPage, pathMatch: 'full' },
    
    { path: Config.ErrorPage, component: ErrorPageComponent, canActivate: [ErrorPageGuard] },
    { path: '**', component: NotFoundComponent },
]

@NgModule({
    imports: [RouterModule.forRoot(routes, {
        useHash: false,
        initialNavigation: 'enabled',
    })],
    exports: [RouterModule]
})
export class AppRoutingModule {

}