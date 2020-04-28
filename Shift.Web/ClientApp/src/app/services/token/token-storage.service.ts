import { Injectable } from "@angular/core";
import { JwtStorageKey } from "src/app/infrastracture/config";
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
    providedIn: 'root'
})
export class TokenStorageService {
    constructor(private jwtHelper: JwtHelperService) {}

    public addToken(token: string) {
        localStorage.setItem(JwtStorageKey, token);
    }

    public removeToken() {
        localStorage.removeItem(JwtStorageKey);
    }

    public getUserRole() {
        var token = localStorage.getItem(JwtStorageKey);
        var tokenObj = this.jwtHelper.decodeToken(token);

        return tokenObj["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    }

    public getToken() {
        return localStorage[JwtStorageKey];
    }
}