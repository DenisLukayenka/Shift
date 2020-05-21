import { Component, OnInit } from "@angular/core";
import { RegisterType } from "src/app/infrastracture/entities/auth/register-types";
import { Router } from "@angular/router";
import { LoginPage } from "src/app/infrastracture/config";

@Component({
    selector: 'pac-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
    public currentType = RegisterType.UnSelected;
    public formType = RegisterType.EmployeeRegister;

    readonly SelectRegisterTypes = [RegisterType.EmployeeRegister, RegisterType.GraduateRegister, RegisterType.UndergraduateRegister];
    readonly RegisterTypes = RegisterType;

    constructor(private router: Router){}

    ngOnInit() {
    }

    public selectTargetType() {
        this.currentType = this.formType;
    }

    public resetCurrentType() {
        this.currentType = RegisterType.UnSelected;
    }

    public goToLogin() {
        this.router.navigateByUrl(LoginPage);
    }
}