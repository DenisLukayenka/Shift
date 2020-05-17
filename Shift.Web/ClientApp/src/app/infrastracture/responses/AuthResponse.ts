import { UserContext } from "../entities/users/UserContext";

export class AuthResponse {
    User: UserContext;
    Alert: string;
    Token: string;
}