import { UserContext } from "./UserContext";

export class AuthResponse {
    User: UserContext;
    Alert: string;
    Token: string;
}