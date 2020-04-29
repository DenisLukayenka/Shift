import { BaseResponse } from "./BaseResponse";

export class AuthResponse extends BaseResponse {
    Token: string;
    Alert: string;
}