import { BaseResponse } from "../responses/BaseResponse";
import { FetchRootMenuResp } from "../responses/FetchRootMenuResp";

export const isRootMenuResponse = (response: BaseResponse) => response.Type === FetchRootMenuResp.fullName;