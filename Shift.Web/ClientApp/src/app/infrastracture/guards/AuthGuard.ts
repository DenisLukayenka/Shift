import { Injectable } from "@angular/core";
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";
import { Observable } from "rxjs";
import { TokenStorageService } from "src/app/services/token/token-storage.service";

@Injectable()
export class AuthGuard implements CanActivate {
    
    constructor(private jwtHelper: JwtHelperService, private router: Router, private storage: TokenStorageService) {}

    canActivate (route: ActivatedRouteSnapshot, state: RouterStateSnapshot ): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        var token = this.storage.getToken();
        if(!!token && !this.jwtHelper.isTokenExpired(token)) {
            console.log(this.jwtHelper.decodeToken(token));
            return true;
        }
        this.router.navigate(["login"]);
        return false;
    }
}