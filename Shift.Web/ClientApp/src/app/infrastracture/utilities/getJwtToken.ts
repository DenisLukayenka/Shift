import { JwtStorageKey } from "../config";

export const getJwtToken = () => localStorage[JwtStorageKey];