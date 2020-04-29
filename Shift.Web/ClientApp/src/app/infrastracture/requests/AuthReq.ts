import { BaseRequest } from "./BaseRequest";
import { RequestType } from "../entities/requests/requestType";
import { ReqOptions } from "../entities/requests/ReqOptions";
import { HttpHeaders } from "@angular/common/http";

export class AuthReq extends BaseRequest {
    Login: string;
    Password: string;

    constructor(login: string, password: string) {
        super();

        this.Login = login;
        this.Password = password;
    }

    get ReqType (): RequestType {
        return RequestType.POST;
    }
    get Body (): any {
        let authModel = {
            Login: this.Login,
            Password: this.Password,
        };

        return JSON.stringify(authModel);
    }
    get Options (): ReqOptions {
        return {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
            }),
        };
    }
    get TargetReqUrl (): string {
        return 'api/auth/login';
    }
}