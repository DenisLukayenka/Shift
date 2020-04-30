import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormControl, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { RegisterPage } from "src/app/infrastracture/config";
import { Store, select } from "@ngrx/store";
import { AppState, selectAuthAlert } from "../../store/app/app.state";
import { TryAuth } from "../../store/app/app.actions";

@Component({
    selector: 'pac-login',
    styleUrls: ['./login.component.scss'],
    templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
    isAuth: boolean;
    authAlert: string;

    options: FormGroup;
    hidePassword = true;

    private loginControl: FormControl;
    private passwordControl: FormControl;

    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
        private appState: Store<AppState>,
    ) {
        this.initializeForm();
    }

    public ngOnInit() {
        this.appState.pipe(select(selectAuthAlert)).subscribe(alert => this.authAlert = alert);
    }
    
    public login() {
        if(!this.options.invalid) {
            this.appState.dispatch(new TryAuth({ login: this.options.value.login, password: this.options.value.password }));
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

    public register() {
        this.router.navigate([RegisterPage]);
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