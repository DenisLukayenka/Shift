import { EducationForm } from "./EducationForm";
import { UserRegisterVM } from "./UserRegisterVM";

export class UndergraduateRegisterVM {
    public User: UserRegisterVM;

    public  EducationForm: EducationForm;

    public SpecialtyId: number;
    public AdviserId: number;

    public StartEducationDate: Date;
    public FinishEducationDate: Date;
}