import { UserRegisterVM } from "./UserRegisterVM";
import { LoginVM } from "./LoginVM";
import { AcademicDegree } from "../users/AcademicDegree";
import { AcademicRank } from "../users/AcademicRank";
import { JobPosition } from "../users/JobPosition";
import { Department } from "../university/Department";

export class EmployeeRegisterVM {
    public User: UserRegisterVM;
    public Login: LoginVM;

    public AcademicDegree: AcademicDegree;
    public AcademicRank: AcademicRank;
    public JobPosition: JobPosition;
    public Department: Department;
}