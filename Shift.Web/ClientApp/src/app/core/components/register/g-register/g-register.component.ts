import { Component, EventEmitter, Output } from "@angular/core";
import { EducationForm } from "src/app/infrastracture/entities/auth/EducationForm";
import { FormGroup, FormBuilder, Validators, FormControl } from "@angular/forms";
import { Observable, from } from "rxjs";
import { SpecialtyVM } from "src/app/infrastracture/entities/university/SpecialtyVM";
import { AdviserListItemVM } from "src/app/infrastracture/entities/users/AdvisersListItemVM";
import { Router } from "@angular/router";
import { StorageService } from "src/app/services/storage/storage.service";
import { HttpProcessorService } from "src/app/services/http-processor/http-processor.service";
import { SpecialtiesReq } from "src/app/infrastracture/requests/data/SpecialtiesReq";
import { AdviserListReq } from "src/app/infrastracture/requests/data/AdviserListReq";
import { castEducationForm } from "src/app/infrastracture/utilities/castEducationForm";
import { LoginVM } from "src/app/infrastracture/entities/auth/LoginVM";
import { markGroupAsDirty } from "src/app/infrastracture/utilities/markAsDirty";
import { GraduateRegisterVM } from "src/app/infrastracture/entities/auth/GraduateRegisterVM";
import { TokenKey, UserIdKey, SpecifiedUserIdKey } from "src/app/services/storage/StorageKeys";
import { RootPage } from "src/app/infrastracture/config";
import { AuthResponse } from "src/app/infrastracture/responses/AuthResponse";
import { RegisterGReq } from "src/app/infrastracture/requests/auth/register/RegisterGReq";
import * as _ from 'lodash';

@Component({
    selector: 'pac-g-register',
    templateUrl: './g-register.component.html',
    styleUrls: ['./g-register.component.scss'],
})
export class GRegisterComponent {
    @Output()
    public resetTargetType: EventEmitter<any> = new EventEmitter();
    public gRegisterGroup: FormGroup;
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
        markGroupAsDirty(this.gRegisterGroup);

        if (!this.gRegisterGroup.invalid) {
            let graduateModel = this.gRegisterGroup.value as GraduateRegisterVM;
            graduateModel.EducationForm = this.EducationFormModel;
            graduateModel.User.Login = this.LoginModel;

            from(this.http.execute(new RegisterGReq(graduateModel))).subscribe((authResp: AuthResponse) => {
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
        this.gRegisterGroup.addControl(groupName, group);
    }

    public get SpecialtyControl(): FormControl {
        return this.gRegisterGroup.get('SpecialtyId') as FormControl;
    }
    public get AdviserControl(): FormControl {
        return this.gRegisterGroup.get('AdviserId') as FormControl;
    }
    public get EducationFormControl(): FormControl {
        return this.gRegisterGroup.get('EducationForm') as FormControl;
    }
    public get LoginGroup(): FormGroup {
        return this.gRegisterGroup.get('User').get('Login') as FormGroup;
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
        this.gRegisterGroup = this.fb.group({
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