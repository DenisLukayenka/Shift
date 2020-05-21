import { BaseRequest } from "./BaseRequest";
import { RequestType } from "./requestType";

export abstract class BasePostRequest extends BaseRequest {
    public get ReqType() {
        return RequestType.POST;
    }
}