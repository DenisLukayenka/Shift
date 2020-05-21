import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { FormGroup, FormBuilder, Validators, FormControl } from "@angular/forms";
import { PasswordErrorStateMatcher } from "./PasswordErrorStateMatcher";
import * as _ from 'lodash';

@Component({
    selector: 'pac-login-register',
    templateUrl: './login-register.component.html',
})
export class LoginRegisterComponent implements OnInit {
    loginOptions: FormGroup;
    passwordsOptions: FormGroup;

    passwordMatcher = new PasswordErrorStateMatcher();
    hidePassword = true;
    hideConfirmPassword = true;

    @Output()
    onLoginFormConfigured = new EventEmitter<FormGroup>();

    constructor(private fb: FormBuilder) {
        this.initializeForm();
    }

    public ngOnInit() {
        this.onLoginFormConfigured.emit(this.loginOptions);
    }

    public validateLogin() {
        if(this.LoginControl.hasError('required')) {
            return 'Логин не может быть пустым';
        } else if(this.LoginControl.hasError('minlength') || this.LoginControl.hasError('maxlength')) {
            return `Логин должен содержать от 2 до 32 символов`;
        }
    }
    public get LoginControl(): FormControl {
        return this.loginOptions.get('Login') as FormControl;
    }

    public validatePassword() {
        if(this.PasswordControl.hasError('required')) {
            return 'Пароль не может быть пустым!';
        } else if(this.PasswordControl.hasError('minlength') || this.PasswordControl.hasError('maxlength')) {
            return 'Пароль должен содержать от 8 до 32 символов'
        }
    }
    public get PasswordControl(): FormControl {
        if (this.loginOptions) {
            return this.loginOptions.get('passwords').get('Password') as FormControl;
        }
    }
    public get ConfirmPasswordControl(): FormControl {
        if (this.loginOptions) {
            return this.loginOptions.get('passwords').get('ConfirmPassword') as FormControl;
        }
    }

    public initializeForm() {
        this.passwordsOptions = this.fb.group({
            Password: ['', [
                Validators.minLength(8),
                Validators.maxLength(32),
                Validators.required,
            ]],
            ConfirmPassword: [''],
        }, { validator: this.checkPasswords });

        this.loginOptions = this.fb.group({
            Login: ['', [
                Validators.minLength(2),
                Validators.maxLength(32),
                Validators.required,
            ]],
            passwords: this.passwordsOptions,
        });
    }

    private checkPasswords(group: FormGroup) {
        let passwordValue = group.get('Password').value;
        let confirmPassword = group.get('ConfirmPassword');

        return ((passwordValue === confirmPassword.value) 
            || (!confirmPassword.touched && !confirmPassword.dirty)) ? null: { notSame: true };
    }
}