import { JwtStorageKey } from "../config";

export const getJwtToken = () => localStorage.getItem(JwtStorageKey);