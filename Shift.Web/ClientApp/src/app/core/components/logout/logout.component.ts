import { Component } from "@angular/core";
import { AppState } from "../../store/app/app.state";
import { Store } from "@ngrx/store";
import { LogOut } from "../../store/app/app.actions";

@Component({
    template: '',
})
export class LogoutComponent {
    constructor(private appState: Store<AppState>) {
        this.appState.dispatch(new LogOut());
    }
}