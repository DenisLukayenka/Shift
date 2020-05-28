import { TokenKey } from "src/app/services/storage/StorageKeys";

export function getJwtToken() {
    return localStorage[TokenKey];
}