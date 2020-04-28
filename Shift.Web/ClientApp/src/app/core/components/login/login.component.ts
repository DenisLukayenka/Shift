import { Component } from "@angular/core";
import { FormBuilder, FormGroup, FormControl, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { from } from "rxjs";
import { HttpProcessorService } from "src/app/services/http-processor/http-processor.service";
import { AuthReq } from "src/app/infrastracture/requests/AuthReq";
import { TokenStorageService } from "src/app/services/token/token-storage.service";
import { RootPage, RegisterPage } from "src/app/infrastracture/config";

@Component({
    selector: 'pac-login',
    styleUrls: ['./login.component.scss'],
    templateUrl: './login.component.html',
})
export class LoginComponent {
    isAuth: boolean;
    authAlert: string;

    options: FormGroup;
    hidePassword = true;

    private loginControl: FormControl;
    private passwordControl: FormControl;

    constructor(
        private formBuilder: FormBuilder, 
        private httpProcessor: HttpProcessorService,
        private storage: TokenStorageService,
        private router: Router
    ) {
        this.initializeForm();
    }
    
    public login() {
        if(!this.options.invalid) {
            from(this.httpProcessor.execute(new AuthReq(this.options.value.login, this.options.value.password)))
                .subscribe(response => {
                    if(response === undefined) {
                        this.authAlert = 'Произошла ошибка при обработке запроса';
                    } else if(response.Alert !== undefined) {
                        this.authAlert = response.Alert;
                    } else if(response.Token === undefined) {
                        this.authAlert = 'Произошла ошибка при получении данных';
                    } else {
                        this.storage.addToken(response.Token);
                        this.router.navigate([RootPage]);
                    }
                })
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