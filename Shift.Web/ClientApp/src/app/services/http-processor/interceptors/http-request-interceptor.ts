import { Injectable } from "@angular/core";
import { Observable, of, throwError } from "rxjs";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from "@angular/common/http";
import { Router } from "@angular/router";
import { catchError } from "rxjs/operators";
import { AuthFailure, AppFailure } from "src/app/core/store/app/app.actions";
import { Store } from "@ngrx/store";
import { AppState } from "src/app/core/store/app/app.state";

@Injectable()
export class HttpRequestInterceptor implements HttpInterceptor {
    constructor(private router: Router, private appState: Store<AppState>) { }
    
    intercept ( req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(catchError((error: any) => this.handleAuthError(error)));
    }

    private handleAuthError(error: HttpErrorResponse): Observable<HttpEvent<any>> {
        if(error.status === 401 || error.status === 403) {
            this.router.navigate(['login']);

            return new Observable<HttpEvent<any>>();
        }
        this.router.navigate(['error']);

        return new Observable<HttpEvent<any>>();
    }
}