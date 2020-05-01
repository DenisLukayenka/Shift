import { BaseRequest } from "./BaseRequest";
import { RequestType } from "./requestType";

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
    get TargetReqUrl (): string {
        return 'api/auth/login';
    }
}