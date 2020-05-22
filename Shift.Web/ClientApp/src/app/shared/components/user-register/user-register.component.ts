import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { FormBuilder, FormGroup, Validators, FormControl } from "@angular/forms";

@Component({
    selector: 'pac-user-register',
    templateUrl: './user-register.component.html',
    styleUrls: ['./user-register.component.scss'],
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
        if(this.FirstNameControl.hasError('required')) {
            return 'Имя не может быть пустым';
        } else if(this.FirstNameControl.hasError('minlength')) {
            return 'Имя должно содержать не менее 2 символов';
        }
    }
    public get FirstNameControl(): FormControl {        
        return this.userRegisterOptions.controls.FirstName as FormControl;
    }

    public validateLastName() {
        if(this.LastNameControl.hasError('required')) {
            return 'Фамилия не может быть пустой';
        } else if(this.LastNameControl.hasError('minlength')) {
            return 'Фамилия должна содержать не менее 2 символов';
        }
    }
    public get LastNameControl(): FormControl {
        return this.userRegisterOptions.get('LastName') as FormControl;
    }

    public validateEmail() {
        if(this.EmailControl.hasError('required')) {
            return 'Электронная почта не может быть пустой';
        } else if(this.EmailControl.hasError('email')) {
            return 'Неверный формат электронной почты';
        }
    }
    public get EmailControl(): FormControl {
        return this.userRegisterOptions.get('Email') as FormControl;
    }

    public addFormGroup(groupName: string, group: FormGroup) {
        this.userRegisterOptions.addControl(groupName, group);
    }

    private initializeForm() {
        this.userRegisterOptions = this.fb.group({
            FirstName: ['', [
                Validators.minLength(2),
                Validators.required
            ]],
            LastName: ['', [
                Validators.minLength(2),
                Validators.required
            ]],
            PatronymicName: [''],
            Email: ['', [
                Validators.email, 
                Validators.required
            ]],
        });
    }
}