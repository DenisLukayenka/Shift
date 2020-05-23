import { BasePostRequest } from "./BasePostRequest";

export abstract class BasePostModelRequest extends BasePostRequest {
    private model: any;

    constructor(model: any) {
        super();
        this.model = model;
    }

    get Body (): any {
        return JSON.stringify(this.model);
    }
}