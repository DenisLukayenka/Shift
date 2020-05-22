import { Component, EventEmitter, Output, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormControl, Validators } from "@angular/forms";
import { HttpProcessorService } from "src/app/services/http-processor/http-processor.service";
import { Observable, from, combineLatest } from "rxjs";
import { AcademicDegree } from "src/app/infrastracture/entities/users/AcademicDegree";
import { AcademicRank } from "src/app/infrastracture/entities/users/AcademicRank";
import { JobPosition } from "src/app/infrastracture/entities/users/JobPosition";
import { DegreesReq } from "src/app/infrastracture/requests/data/DegreesReq";
import { RanksReq } from "src/app/infrastracture/requests/data/RanksReq";
import { PositionsReq } from "src/app/infrastracture/requests/data/PositionsReq";
import { startWith, map } from "rxjs/operators";
import { Department } from "src/app/infrastracture/entities/university/Department";
import { DepartmentsReq } from "src/app/infrastracture/requests/data/DepartmentsReq";
import * as _ from 'lodash';
import { LoginVM } from "src/app/infrastracture/entities/auth/LoginVM";
import { RegisterEmployeeReq } from "src/app/infrastracture/requests/auth/register/RegisterEmployeeReq";
import { markGroupAsDirty } from "src/app/infrastracture/utilities/markAsDirty";
import { AuthResponse } from "src/app/infrastracture/responses/AuthResponse";
import { StorageService } from "src/app/services/storage/storage.service";
import { TokenKey, UserIdKey, SpecifiedUserIdKey } from "src/app/services/storage/StorageKeys";
import { RootPage } from "src/app/infrastracture/config";
import { Router } from "@angular/router";

@Component({
    selector: 'pac-e-register',
    templateUrl: './e-register.component.html',
    styleUrls: ['./e-register.component.scss'],
})
export class ERegisterComponent implements OnInit {
    @Output()
    public resetTargetType: EventEmitter<any> = new EventEmitter();
    public eRegisterGroup: FormGroup;

    public filteredDegrees$: Observable<AcademicDegree[]>;
    public filteredRanks$: Observable<AcademicRank[]>;
    public filteredPositions$: Observable<JobPosition[]>;
    public filteredDepartments$: Observable<Department[]>;
    public authAlert: string;

    private degrees$: Observable<AcademicDegree[]>;
    private ranks$: Observable<AcademicRank[]>;
    private positions$: Observable<JobPosition[]>;
    private departments$: Observable<Department[]>;

    constructor(
        private fb: FormBuilder, 
        private http: HttpProcessorService, 
        private storage: StorageService, 
        private router: Router
    ) {
        this.initializeForm();

        this.degrees$ = from(this.http.execute(new DegreesReq()));
        this.ranks$ = from(this.http.execute(new RanksReq()));
        this.positions$ = from(this.http.execute(new PositionsReq()));
        this.departments$ = from(this.http.execute(new DepartmentsReq()));
    }

    public ngOnInit() {
        this.filteredDegrees$ = combineLatest(this.AcademicDegreeControl.valueChanges.pipe(startWith("")), this.degrees$)
            .pipe(map(([value, degrees]) => this._filterDegrees(degrees, value)));

        this.filteredRanks$ = combineLatest(this.AcademicRankControl.valueChanges.pipe(startWith("")), this.ranks$)
            .pipe(map(([value, ranks]) => this._filterRanks(ranks, value)));

        this.filteredPositions$ = combineLatest(this.JobPositionControl.valueChanges.pipe(startWith("")), this.positions$)
            .pipe(map(([value, positions]) => this._filterPositions(positions, value)));

        this.filteredDepartments$ = combineLatest(this.DepartmentControl.valueChanges.pipe(startWith("")), this.departments$)
            .pipe(map(([value, departments]) => this._filterDepartments(departments, value)));
    }

    public resetTarget() {
        this.resetTargetType.emit();
    }

    public addFormGroup(groupName: string, group: FormGroup){
        this.eRegisterGroup.addControl(groupName, group);
    }

    public submit() {
        markGroupAsDirty(this.eRegisterGroup);

        if(this.eRegisterGroup.invalid) {
            return;
        }

        let employeeModel = this.eRegisterGroup.value;
        employeeModel.AcademicDegree = this.DegreeModel;
        employeeModel.AcademicRank = this.RankModel;
        employeeModel.JobPosition = this.PositionModel;
        employeeModel.Department = this.DepartmentModel;
        employeeModel.User.Login = this.LoginModel;

        from(this.http.execute(new RegisterEmployeeReq(employeeModel))).subscribe((authResp: AuthResponse) => {
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

    public displayWithDegree(degree: AcademicDegree) {
        return degree ? degree.DegreeName : '';
    }
    public displayWithRank(rank: AcademicRank) {
        return rank ? rank.RankName : '';
    }
    public displayWithPosition(position: JobPosition) {
        return position ? position.Name : '';
    }
    public displayWithDepartment(department: Department) {
        return department ? department.Name : '';
    }

    private initializeForm() {
        this.eRegisterGroup = this.fb.group({
            AcademicDegree: [null],
            AcademicRank: [null],
            JobPosition: [null],
            Department: [null],
        });
    }

    public get AcademicDegreeControl(): FormControl {
        return this.eRegisterGroup.get('AcademicDegree') as FormControl;
    }
    public get AcademicRankControl(): FormControl {
        return this.eRegisterGroup.get('AcademicRank') as FormControl;
    }
    public get JobPositionControl(): FormControl {
        return this.eRegisterGroup.get('JobPosition') as FormControl;
    }
    public get DepartmentControl(): FormControl {
        return this.eRegisterGroup.get('Department') as FormControl;
    }
    public get LoginGroup(): FormGroup {
        return this.eRegisterGroup.get('User').get('Login') as FormGroup;
    }

    private _filterDegrees(degrees: AcademicDegree[], value: any): AcademicDegree[] {
        const filterValue = value.DegreeName ? value.DegreeName : value.toLowerCase();
    
        return degrees.filter(option => option.DegreeName.toLowerCase().indexOf(filterValue) === 0);
    }
    private _filterRanks(ranks: AcademicRank[], value: any): AcademicRank[] {
        const filterValue = value.RankName ? value.RankName : value.toLowerCase();
    
        return ranks.filter(option => option.RankName.toLowerCase().indexOf(filterValue) === 0);
    }
    private _filterPositions(positions: JobPosition[], value: any): JobPosition[] {
        const filterValue = value.Name ? value.Name : value.toLowerCase();
    
        return positions.filter(option => option.Name.toLowerCase().indexOf(filterValue) === 0);
    }
    private _filterDepartments(departments: Department[], value: any): Department[] {
        const filterValue = value.Name ? value.Name : value.toLowerCase();
    
        return departments.filter(option => option.Name.toLowerCase().indexOf(filterValue) === 0);
    }

    private get DegreeModel(): AcademicDegree {
        let controlValue = _.cloneDeep(this.AcademicDegreeControl.value);
        if (!controlValue) {
            return null;
        }

        if (!controlValue || !controlValue.Id) {
            return {
                DegreeName: controlValue,
                Id: null,
            };
        }

        return controlValue;
    }
    private get RankModel(): AcademicRank {
        let controlValue = _.cloneDeep(this.AcademicRankControl.value);
        if (!controlValue) {
            return null;
        }

        if (!controlValue.Id) {
            return {
                RankName: controlValue,
                Id: null,
            };
        }

        return controlValue;
    }
    private get PositionModel(): JobPosition {
        let controlValue = _.cloneDeep(this.JobPositionControl.value);
        if (!controlValue) {
            return null;
        }

        if (!controlValue.Id) {
            return {
                Name: controlValue,
                Id: null,
            };
        }

        return controlValue;
    }
    private get DepartmentModel(): Department {
        let controlValue = _.cloneDeep(this.DepartmentControl.value);
        if (!controlValue) {
            return null;
        }

        if (!controlValue.Id) {
            return {
                Name: controlValue,
                Id: null,
            };
        }

        return controlValue;
    }

    private get LoginModel(): LoginVM {
        let controlValue = _.cloneDeep(this.LoginGroup.value);

        return {
            Login: controlValue.Login,
            Password: controlValue.passwords.Password,
        }
    }
}