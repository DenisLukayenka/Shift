import { RequestType } from "./requestType";
import { ReqOptions } from "./ReqOptions";
import { SERVER_URL } from "../config";

export abstract class BaseRequest {
    get ReqUrl(): string {
        return SERVER_URL + this.TargetReqUrl;
    }

    abstract get ReqType(): RequestType;
    abstract get Body();
    abstract get TargetReqUrl(): string;

    get Options(): ReqOptions {
        return new ReqOptions();
    }
}