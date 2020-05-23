import { UserRegisterVM } from "./UserRegisterVM";

export class GraduateRegisterVM {
    public User: UserRegisterVM;

    public  EducationForm: number;

    public SpecialtyId: number;
    public AdviserId: number;

    public StartEducationDate: Date;
    public FinishEducationDate: Date;
}