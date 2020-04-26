import { RootMenu } from "../entities/menu/RootMenu";
import { BaseResponse } from "./BaseResponse";

export class FetchRootMenuResp extends BaseResponse {
    static fullName = 'RootMenuResponse';
    Type = FetchRootMenuResp.fullName;

    RootMenu: RootMenu;
}