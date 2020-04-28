import { Component } from "@angular/core";
import { NgForm, FormBuilder, FormGroupDirective, FormGroup, FormControl, Validators } from "@angular/forms";
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
    isAuth$: Observable<boolean>;
    authAlert$: Observable<string>;
    options: FormGroup;

    hidePassword = true;
    private loginControl: FormControl;
    private passwordControl: FormControl;

    constructor(private appStore: Store<AppState>, private formBuilder: FormBuilder) {
        this.isAuth$ = this.appStore.pipe(select(selectIsAuth));
        this.authAlert$ = this.appStore.pipe(select(selectAuthAlert));

        this.initializeForm();
    }
    
    public login() {
        if(!this.options.invalid) {
            this.appStore.dispatch(new TryAuth({ login: this.options.value.login, password: this.options.value.password }));
        }
    }

    public validateLogin() {
        if(this.loginControl.hasError('required')) {
            return 'Логин не может быть пустым!';
        } else if(this.loginControl.hasError('minlength') || this.loginControl.hasError('maxlength')) {
            return `Логин должен содержать от 2 до 32 символов!`;
        }
    }

    public validatePassword() {
        if(this.passwordControl.hasError('required')) {
            return 'Пароль не может быть пустым!';
        } else if(this.passwordControl.hasError('minlength') || this.passwordControl.hasError('maxlength')) {
            return 'Пароль должен содержать от 8 до 64 символов!'
        }
    }

    public clearPassword() {
        this.passwordControl.reset();
    }

    public clearLogin() {
        this.loginControl.reset();
    }

    private initializeForm() {
        this.loginControl = new FormControl('', [
            Validators.minLength(2),
            Validators.maxLength(32),
            Validators.required,
        ]);
        this.passwordControl = new FormControl('', [
            Validators.minLength(8),
            Validators.maxLength(64),
            Validators.required,
        ]);

        this.options = this.formBuilder.group({
            login: this.loginControl,
            password: this.passwordControl
        });
    }
}