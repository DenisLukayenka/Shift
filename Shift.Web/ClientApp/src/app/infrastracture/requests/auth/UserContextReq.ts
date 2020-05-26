import { BasePostRequest } from "../BasePostRequest";

export class UserContextReq extends BasePostRequest {
    private userId: number;

    constructor(userId: number) {
        super();

        this.userId = userId;
    }

    get Body(): any {
        return JSON.stringify(this.userId);
    };
    
    TargetReqUrl: string = 'api/auth/userContext';
}