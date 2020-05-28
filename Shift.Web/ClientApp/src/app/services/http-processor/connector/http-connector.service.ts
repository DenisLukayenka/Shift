import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { BaseRequest } from "src/app/infrastracture/requests/BaseRequest";
import { BaseGetRequest } from "src/app/infrastracture/requests/BaseGetRequest";
import { BasePostRequest } from "src/app/infrastracture/requests/BasePostRequest";

@Injectable({
    providedIn: 'root'
})
export class HttpConnectorService {    
    constructor(private http: HttpClient) {}

    async getRequest(request: BaseGetRequest): Promise<any> {
        return this.http.get<any>(request.ReqUrl, request.Options ).toPromise();
    }

    async postRequest(request: BasePostRequest): Promise<any> {
        return this.http.post<any>(request.ReqUrl, request.Body, request.Options).toPromise();
    }

    async putRequest(request: BaseRequest): Promise<any> {
        return this.http.put<any>(request.ReqUrl, request.Body, request.Options).toPromise();
    }

    async deleteRequest(request: BaseRequest): Promise<any> {
        return this.http.delete<any>(request.ReqUrl, request.Options).toPromise();
    }
}