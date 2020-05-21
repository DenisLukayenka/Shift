import { Component, EventEmitter, Output, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormControl } from "@angular/forms";
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

    private degrees$: Observable<AcademicDegree[]>;
    private ranks$: Observable<AcademicRank[]>;
    private positions$: Observable<JobPosition[]>;
    private departments$: Observable<Department[]>;

    constructor(private fb: FormBuilder, private http: HttpProcessorService) {
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
        /*if(this.eRegisterGroup.invalid) {
            return;
        }*/

        let employeeModel = this.eRegisterGroup.value;
        employeeModel.AcademicDegree = this.DegreeModel;
        employeeModel.AcademicRank = this.RankModel;
        employeeModel.JobPosition = this.PositionModel;
        employeeModel.Department = this.DepartmentModel;
        employeeModel.Login = this.LoginModel;

        from(this.http.execute(new RegisterEmployeeReq(employeeModel))).subscribe(result => {
            console.log(result);
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
            AcademicDegree: this.fb.control(null),
            AcademicRank: this.fb.control(null),
            JobPosition: this.fb.control(null),
            Department: this.fb.control(null),
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
        return this.eRegisterGroup.get('Login') as FormGroup;
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
        if (!controlValue || !controlValue.Id) {
            return {
                RankName: controlValue,
                Id: null,
            };
        }

        return controlValue;
    }
    private get PositionModel(): JobPosition {
        let controlValue = _.cloneDeep(this.JobPositionControl.value);
        if (!controlValue || !controlValue.Id) {
            return {
                Name: controlValue,
                Id: null,
            };
        }

        return controlValue;
    }
    private get DepartmentModel(): Department {
        let controlValue = _.cloneDeep(this.DepartmentControl.value);
        if (!controlValue || !controlValue.Id) {
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