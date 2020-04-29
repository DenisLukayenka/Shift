import { RootMenu } from "../entities/menu/RootMenu";
import { BaseResponse } from "./BaseResponse";

export class FetchRootMenuResp extends BaseResponse {
    RootMenu: RootMenu;
}