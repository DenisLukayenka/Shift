import { UserRegisterVM } from "./UserRegisterVM";
import { AcademicDegree } from "../users/AcademicDegree";
import { AcademicRank } from "../users/AcademicRank";
import { JobPosition } from "../users/JobPosition";
import { Department } from "../university/Department";

export class EmployeeRegisterVM {
    public User: UserRegisterVM;

    public AcademicDegree: AcademicDegree;
    public AcademicRank: AcademicRank;
    public JobPosition: JobPosition;
    public Department: Department;
}