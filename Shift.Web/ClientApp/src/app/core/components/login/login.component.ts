import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { JwtStorageKey } from "src/app/infrastracture/config";
import { AppState, selectIsAuth, selectAuthAlert } from "../../store/app/app.state";
import { Store, select } from "@ngrx/store";
import { TryAuth } from "../../store/app/app.actions";
import { Observable } from "rxjs";

@Component({
    selector: 'pac-login',
    styleUrls: ['./login.component.scss'],
    templateUrl: './login.component.html',
})
export class LoginComponent {
    isAuth: boolean;
    authAlert$: Observable<string>;

    constructor(private appStore: Store<AppState>) {
        this.appStore.pipe(select(selectIsAuth)).subscribe(result => this.isAuth = result);

        this.authAlert$ = this.appStore.pipe(select(selectAuthAlert));
    }
    
    public login(form: NgForm) {
        this.appStore.dispatch(new TryAuth({ login: form.value.login, password: form.value.password }));
    }
}