import { BaseRequest } from "./BaseRequest";
import { RequestType } from "./requestType";

export abstract class BaseGetRequest extends BaseRequest {
    public get ReqType() {
        return RequestType.GET;
    }

    public get Body() {
        return '';
    }
}