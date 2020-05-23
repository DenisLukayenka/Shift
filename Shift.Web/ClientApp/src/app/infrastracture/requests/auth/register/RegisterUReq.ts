import { BasePostModelRequest } from '../../BasePostModelRequest';

export class RegisterUReq extends BasePostModelRequest {
    TargetReqUrl: string = 'api/auth/register/undergraduate';
}