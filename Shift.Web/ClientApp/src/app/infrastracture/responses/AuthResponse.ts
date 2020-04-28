import { BaseResponse } from "./BaseResponse";

export class AuthResponse extends BaseResponse {
    static fullName = 'AuthResponse';
    Type: string = AuthResponse.fullName;

    Token: string;
    Alert: string;
}