import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { ToolbarComponent } from "./core/components/toolbar/toolbar.component";
import { RootViewComponent } from "./core/components/root-view/root-view.component";

const routes: Routes = [
    { path: 'toolbar', component: ToolbarComponent },
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}