import { RequestType } from "../entities/requests/requestType";
import { ReqOptions } from "../entities/requests/ReqOptions";
import { SERVER_URL } from "../config";

export abstract class BaseRequest {
    get ReqUrl(): string {
        return SERVER_URL + this.TargetReqUrl;
    }

    abstract get ReqType(): RequestType;
    abstract get Body();
    abstract get Options(): ReqOptions;
    abstract get TargetReqUrl(): string;
}