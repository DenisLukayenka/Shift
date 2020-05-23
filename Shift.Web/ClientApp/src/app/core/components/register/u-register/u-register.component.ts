import { Component, EventEmitter, Output, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators, FormControl } from "@angular/forms";
import { StorageService } from "src/app/services/storage/storage.service";
import { Router } from "@angular/router";
import { EducationForm } from "src/app/infrastracture/entities/auth/EducationForm";
import { Observable, from, combineLatest } from "rxjs";
import { SpecialtyVM } from "src/app/infrastracture/entities/university/SpecialtyVM";
import { AdviserListItemVM } from "src/app/infrastracture/entities/users/AdvisersListItemVM";
import { HttpProcessorService } from "src/app/services/http-processor/http-processor.service";
import { SpecialtiesReq } from "src/app/infrastracture/requests/data/SpecialtiesReq";
import { AdviserListReq } from "src/app/infrastracture/requests/data/AdviserListReq";
import { map, startWith } from "rxjs/operators";
import * as _ from 'lodash';
import { UndergraduateRegisterVM } from "src/app/infrastracture/entities/auth/UndergraduateRegisterVM";
import { markGroupAsDirty } from "src/app/infrastracture/utilities/markAsDirty";
import { RegisterUReq } from "src/app/infrastracture/requests/auth/register/RegisterUReq";
import { AuthResponse } from "src/app/infrastracture/responses/AuthResponse";
import { TokenKey, UserIdKey, SpecifiedUserIdKey } from "src/app/services/storage/StorageKeys";
import { RootPage } from "src/app/infrastracture/config";
import { castEducationForm } from "src/app/infrastracture/utilities/castEducationForm";
import { LoginVM } from "src/app/infrastracture/entities/auth/LoginVM";

@Component({
    selector: 'pac-u-register',
    templateUrl: './u-register.component.html',
    styleUrls: ['./u-register.component.scss'],
})
export class URegisterComponent {
    @Output()
    public resetTargetType: EventEmitter<any> = new EventEmitter();
    public uRegisterGroup: FormGroup;
    public authAlert: string;

    public educationForms: EducationForm[] = [EducationForm.DAILY, EducationForm.CORRESPONDENCE];

    public specialties$: Observable<SpecialtyVM[]>;
    public advisers$: Observable<AdviserListItemVM[]>;

    constructor(
        private fb: FormBuilder, 
        private router: Router, 
        private storage: StorageService,
        private http: HttpProcessorService
    ) {
        this.initializeFormGroup();

        this.specialties$ = from(this.http.execute(new SpecialtiesReq()));
        this.advisers$ = from(this.http.execute(new AdviserListReq()));
    }

    public resetTarget() {
        this.resetTargetType.emit();
    }

    public submit() {
        markGroupAsDirty(this.uRegisterGroup);

        if (!this.uRegisterGroup.invalid) {
            let undergraduateModel = this.uRegisterGroup.value as UndergraduateRegisterVM;
            undergraduateModel.EducationForm = this.EducationFormModel;
            undergraduateModel.User.Login = this.LoginModel;

            from(this.http.execute(new RegisterUReq(undergraduateModel))).subscribe((authResp: AuthResponse) => {
                if(authResp.Alert) {
                    this.authAlert = authResp.Alert;
                    return;
                }
    
                this.storage.setValue(TokenKey, authResp.Token);
                this.storage.setValue(UserIdKey, authResp.User.UserId.toString());
                this.storage.setValue(SpecifiedUserIdKey, authResp.User.SpecifiedUserId.toString());
                this.router.navigate([RootPage]);
            });
        }
    }

    public addFormGroup(groupName: string, group: FormGroup) {
        this.uRegisterGroup.addControl(groupName, group);
    }

    public get SpecialtyControl(): FormControl {
        return this.uRegisterGroup.get('SpecialtyId') as FormControl;
    }
    public get AdviserControl(): FormControl {
        return this.uRegisterGroup.get('AdviserId') as FormControl;
    }
    public get EducationFormControl(): FormControl {
        return this.uRegisterGroup.get('EducationForm') as FormControl;
    }
    public get LoginGroup(): FormGroup {
        return this.uRegisterGroup.get('User').get('Login') as FormGroup;
    }

    public validateAdviserControl() {
        if(this.AdviserControl.hasError('required')) {
            return 'Необходимо выбрать научного руководителя';
        }
    }

    private get LoginModel(): LoginVM {
        let controlValue = _.cloneDeep(this.LoginGroup.value);

        return {
            Login: controlValue.Login,
            Password: controlValue.passwords.Password,
        }
    }

    private get EducationFormModel() {
        return castEducationForm(this.EducationFormControl.value);
    }

    private initializeFormGroup() {
        this.uRegisterGroup = this.fb.group({
            EducationForm: [EducationForm.DAILY],
            SpecialtyId: [null],
            AdviserId: [null, [
                Validators.required,
            ]],
            StartEducationDate: [null],
            FinishEducationDate: [null],
        });
    }
}