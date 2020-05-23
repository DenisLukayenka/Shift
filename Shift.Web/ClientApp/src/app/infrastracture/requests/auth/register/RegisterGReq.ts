import { BasePostModelRequest } from "../../BasePostModelRequest";

export class RegisterGReq extends BasePostModelRequest {
    TargetReqUrl: string = 'api/auth/register/graduate';
}