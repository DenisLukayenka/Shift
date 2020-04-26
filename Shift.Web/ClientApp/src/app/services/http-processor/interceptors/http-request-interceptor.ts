import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from "@angular/common/http";

@Injectable()
export class HttpRequestInterceptor implements HttpInterceptor {
    intercept ( req: HttpRequest<any>, next: HttpHandler ): Observable<HttpEvent<any>> {
        return next.handle(req);
    }
}