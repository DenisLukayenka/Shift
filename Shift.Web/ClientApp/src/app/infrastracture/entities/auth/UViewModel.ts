import { EducationForm } from "./EducationForm";

export class UViewModel {
    public FirstName: string;
    public LastName:  string;
    public PatronymicName: string

    public Email: string

    public Login: string;
    public Password: string;

    public  EducationForm: EducationForm;

    public SpecialtyId: number;

    public AdviserId: number;

    public StartEducationDate: Date;
    public FinishEducationDate: Date;
}