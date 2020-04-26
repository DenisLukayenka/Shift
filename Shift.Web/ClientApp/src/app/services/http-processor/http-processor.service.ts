import { Injectable } from "@angular/core";
import { HttpConnectorService } from "./connector/http-connector.service";
import { BaseRequest } from "src/app/infrastracture/requests/BaseRequest";
import { BaseResponse } from "src/app/infrastracture/responses/BaseResponse";
import { RequestType } from "src/app/infrastracture/entities/requests/requestType";

@Injectable({
    providedIn: 'root'
})
export class HttpProcessorService {
    constructor(private connector: HttpConnectorService) {
    }

    public execute(request: BaseRequest): Promise<BaseResponse> {
        switch(request.ReqType){
            case RequestType.GET:
                return this.connector.getRequest(request);
            case RequestType.POST:
                return this.connector.postRequest(request);
            case RequestType.PUT:
                return this.connector.putRequest(request);
            case RequestType.DELETE:
                return this.connector.deleteRequest(request);
        }
    }
}