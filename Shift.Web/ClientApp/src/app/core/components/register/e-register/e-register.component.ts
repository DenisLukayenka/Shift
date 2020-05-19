import { Component, EventEmitter, Output, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormControl } from "@angular/forms";
import { HttpProcessorService } from "src/app/services/http-processor/http-processor.service";
import { Observable, from, pipe, combineLatest } from "rxjs";
import { AcademicDegree } from "src/app/infrastracture/entities/users/AcademicDegree";
import { AcademicRank } from "src/app/infrastracture/entities/users/AcademicRank";
import { JobPosition } from "src/app/infrastracture/entities/users/JobPosition";
import { DegreesReq } from "src/app/infrastracture/requests/data/DegreesReq";
import { RanksReq } from "src/app/infrastracture/requests/data/RanksReq";
import { PositionsReq } from "src/app/infrastracture/requests/data/PositionsReq";
import { startWith, map, filter, debounceTime, distinctUntilChanged } from "rxjs/operators";

@Component({
    selector: 'pac-e-register',
    templateUrl: './e-register.component.html',
    styleUrls: ['./e-register.component.scss'],
})
export class ERegisterComponent implements OnInit {
    @Output()
    public resetTargetType: EventEmitter<any> = new EventEmitter();
    public eRegisterGroup: FormGroup;

    public degrees$: Observable<AcademicDegree[]>;
    public ranks$: Observable<AcademicRank[]>;
    public positions$: Observable<JobPosition[]>;

    public filteredDegrees$: Observable<AcademicDegree[]>;
    public filteredRanks$: Observable<AcademicRank[]>;
    public filteredPositions$: Observable<JobPosition[]>;

    constructor(private fb: FormBuilder, private http: HttpProcessorService) {
        this.initializeForm();

        this.degrees$ = from(this.http.execute(new DegreesReq()));
        this.ranks$ = from(this.http.execute(new RanksReq()));
        this.positions$ = from(this.http.execute(new PositionsReq()));
    }

    public ngOnInit() {
        this.filteredDegrees$ = combineLatest(this.AcademicDegreeControl.valueChanges.pipe(startWith("")), this.degrees$)
            .pipe(map(([value, degrees]) => this._filterDegrees(degrees, value)));

        this.filteredRanks$ = combineLatest(this.AcademicRankControl.valueChanges.pipe(startWith("")), this.ranks$)
            .pipe(map(([value, ranks]) => this._filterRanks(ranks, value)));

        this.filteredPositions$ = combineLatest(this.JobPositionControl.valueChanges.pipe(startWith("")), this.positions$)
            .pipe(map(([value, positions]) => this._filterPositions(positions, value)));
    }

    public resetTarget() {
        this.resetTargetType.emit();
    }

    public addFormGroup(groupName: string, group: FormGroup){
        this.eRegisterGroup.addControl(groupName, group);
    }

    public submit() {
        var a = this.eRegisterGroup.value;

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

    private initializeForm() {
        this.eRegisterGroup = this.fb.group({
            AcademicDegree: this.fb.control(null),
            AcademicRank: this.fb.control(null),
            JobPosition: this.fb.control(null),
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
}