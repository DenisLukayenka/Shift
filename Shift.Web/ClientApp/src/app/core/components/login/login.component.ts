import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { JwtStorageKey } from "src/app/infrastracture/config";
import { AppState } from "../../store/app/app.state";
import { Store } from "@ngrx/store";
import { TryAuth } from "../../store/app/app.actions";

@Component({
    selector: 'pac-login',
    styleUrls: ['./login.component.scss'],
    templateUrl: './login.component.html',
})
export class LoginComponent {
    invalidLogin: boolean = false;

    constructor(private appStore: Store<AppState>) { }
    
    public login(form: NgForm) {
        this.appStore.dispatch(new TryAuth({ login: form.value.login, password: form.value.password }));
    }
}