import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from "@angular/common/http";
import { Router } from "@angular/router";
import { catchError } from "rxjs/operators";
import { ErrorPage, LoginPage } from "src/app/infrastracture/config";

@Injectable()
export class HttpRequestInterceptor implements HttpInterceptor {
    constructor(private router: Router) { }
    
    intercept ( req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const newReq = req.clone({
            headers: req.headers.set('Content-Type', 'application/json')
        });

        return next.handle(newReq).pipe(catchError((error: any) => this.handleAuthError(error)));
    }

    private handleAuthError(error: HttpErrorResponse): Observable<HttpEvent<any>> {
        let errorMessage = '';

        if (error.error instanceof ErrorEvent) {
            errorMessage = `Error: ${error.error.message}`;
        } else {
            errorMessage = `Error code: ${error.status}\n${error.message}\n${error.error}`;
            if (error.status === 401) {
                this.router.navigate([LoginPage]);
            }

            if (error.status >= 500) {
                this.router.navigate([ErrorPage])
            }
        }

        return throwError(errorMessage);
    }
}