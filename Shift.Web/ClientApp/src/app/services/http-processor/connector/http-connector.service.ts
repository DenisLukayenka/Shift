import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { BaseRequest } from "src/app/infrastracture/requests/BaseRequest";
import { BaseResponse } from "src/app/infrastracture/responses/BaseResponse";

@Injectable({
    providedIn: 'root'
})
export class HttpConnectorService {    
    constructor(private http: HttpClient) {}

    async getRequest(request: BaseRequest): Promise<BaseResponse> {
        try {
            return this.http.get<BaseResponse>(request.ReqUrl, request.Options ).toPromise();
        } catch (error) {
            console.log("error at get method", error);
        }
    }

    async postRequest(request: BaseRequest): Promise<BaseResponse> {
        try {
            return this.http.post<BaseResponse>(request.ReqUrl, request.Body, request.Options).toPromise();
        } catch (error) {
            console.log("error at post method", error);
        }
    }

    async putRequest(request: BaseRequest): Promise<BaseResponse> {
        try {
            return this.http.put<BaseResponse>(request.ReqUrl, request.Body, request.Options).toPromise();
        } catch (error) {
            console.log("error at put method", error);
        }
    }

    async deleteRequest(request: BaseRequest): Promise<BaseResponse> {
        try {
            return this.http.delete<BaseResponse>(request.ReqUrl, request.Options).toPromise();
        } catch (error) {
            console.log("error at put method", error);
        }
    }
}