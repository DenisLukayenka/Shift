import { Injectable } from "@angular/core";
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";
import { Observable } from "rxjs";
import { StorageService } from "src/app/services/storage/storage.service";
import { TokenKey } from "src/app/services/storage/StorageKeys";
import { LoginPage } from "../config";

@Injectable()
export class AuthGuard implements CanActivate {
    
    constructor(private jwtHelper: JwtHelperService, private router: Router, private storage: StorageService) {}

    canActivate (route: ActivatedRouteSnapshot, state: RouterStateSnapshot ): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        var token = this.storage.getValue(TokenKey);
        if(!!token && !this.jwtHelper.isTokenExpired(token)) {
            console.log(this.jwtHelper.decodeToken(token));
            return true;
        }
        this.router.navigate([LoginPage]);
        return false;
    }
}