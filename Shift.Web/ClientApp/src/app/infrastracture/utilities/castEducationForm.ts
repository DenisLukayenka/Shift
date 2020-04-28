import { EducationForm } from "../entities/auth/EducationForm";

export const castEducationForm = (form: EducationForm) => form === EducationForm.DAILY ? 0: 1;