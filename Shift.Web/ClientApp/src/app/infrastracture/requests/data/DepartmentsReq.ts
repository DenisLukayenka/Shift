import { BaseGetRequest } from "../BaseGetRequest";

export class DepartmentsReq extends BaseGetRequest {
    TargetReqUrl: string = 'api/data/departments';
}