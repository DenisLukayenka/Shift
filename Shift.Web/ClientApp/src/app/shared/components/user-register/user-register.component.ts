import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { FormBuilder, FormGroup, Validators, FormControl } from "@angular/forms";

@Component({
    selector: 'pac-user-register',
    templateUrl: './user-register.component.html',
})
export class UserRegisterComponent implements OnInit {
    userRegisterOptions: FormGroup;

    @Output()
    onUserRegisterConfigured: EventEmitter<FormGroup> = new EventEmitter<FormGroup>();

    constructor(private fb: FormBuilder) {
        this.initializeForm();
    }

    public ngOnInit() {
        this.onUserRegisterConfigured.emit(this.userRegisterOptions);
    }

    public validateFirstName() {
        if(this.getFirstNameControl.hasError('required')) {
            return 'Имя не может быть пустым';
        } else if(this.getFirstNameControl.hasError('minlength')) {
            return 'Имя должно содержать не менее 2 символов';
        }
    }
    public get getFirstNameControl(): FormControl {
        let a = this.userRegisterOptions.get('FirstName') as FormControl;;
        let b = a.invalid;
        
        return this.userRegisterOptions.get('FirstName') as FormControl;
    }

    public validateLastName() {
        if(this.getLastNameControl.hasError('required')) {
            return 'Фамилия не может быть пустой';
        } else if(this.getLastNameControl.hasError('minlength')) {
            return 'Фамилия должна содержать не менее 2 символов';
        }
    }
    public get getLastNameControl(): FormControl {
        return this.userRegisterOptions.get('LastName') as FormControl;
    }

    public validateEmail() {
        if(this.getEmailControl.hasError('required')) {
            return 'Электронная почта не может быть пустой';
        } else if(this.getEmailControl.hasError('email')) {
            return 'Неверный формат электронной почты';
        }
    }
    public get getEmailControl(): FormControl {
        return this.userRegisterOptions.get('Email') as FormControl;
    }

    private initializeForm() {
        this.userRegisterOptions = this.fb.group({
            FirstName: this.fb.control('', [
                Validators.minLength(2),
                Validators.required
            ]),
            LastName: this.fb.control('', [
                Validators.minLength(2),
                Validators.required
            ]),
            PatronymicName: this.fb.control(''),
            Email: this.fb.control('', [Validators.email, Validators.required]),
        });
    }
}