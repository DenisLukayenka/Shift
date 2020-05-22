import { Component, EventEmitter, Output } from "@angular/core";
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

    public filteredSpecialties$: Observable<SpecialtyVM[]>;
    public filteredAdvisers$: Observable<AdviserListItemVM[]>;

    private specialties$: Observable<SpecialtyVM[]>;
    private advisers$: Observable<AdviserListItemVM[]>;

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
        let a = this.uRegisterGroup.value;
        console.log(a);
    }

    public addFormGroup(groupName: string, group: FormGroup) {
        this.uRegisterGroup.addControl(groupName, group);
    }

    public get SpecialtyControl(): FormControl {
        return this.uRegisterGroup.get('Specialty') as FormControl;
    }
    public get AdviserControl(): FormControl {
        return this.uRegisterGroup.get('Adviser') as FormControl;
    }

    public displayWithSpecialty(specialty: SpecialtyVM) {
        return specialty ? specialty.Title : '';
    }
    public displayWithAdviser(adviser: AdviserListItemVM) {
        return adviser ? adviser.Name : '';
    }

    private _filterSpecialties(degrees: SpecialtyVM[], value: any): SpecialtyVM[] {
        const filterValue = value.Title ? value.Title : value.toLowerCase();
    
        return degrees.filter(option => option.Title.toLowerCase().indexOf(filterValue) === 0);
    }
    private _filterAdvisers(advisers: AdviserListItemVM[], value: any): AdviserListItemVM[] {
        const filterValue = value.Name ? value.Name : value.toLowerCase();
    
        return advisers.filter(option => option.Name.toLowerCase().indexOf(filterValue) === 0);
    }

    private initializeFormGroup() {
        this.uRegisterGroup = this.fb.group({
            EducationForm: [EducationForm.DAILY],
            Specialty: [null],
            Adviser: [null, [
                Validators.required,
            ]],
            StartEducationDate: [null, [
                Validators.required
            ]],
            FinishEducationDate: [null, [
                Validators.required,
            ]],
        });

        this.filteredSpecialties$ = combineLatest(this.SpecialtyControl.valueChanges.pipe(startWith("")), this.specialties$)
            .pipe(map(([value, specialties]) => this._filterSpecialties(specialties, value)));
        this.filteredAdvisers$ = combineLatest(this.AdviserControl.valueChanges.pipe(startWith("")), this.advisers$)
            .pipe(map(([value, advisers]) => this._filterAdvisers(advisers, value)));
    }
}