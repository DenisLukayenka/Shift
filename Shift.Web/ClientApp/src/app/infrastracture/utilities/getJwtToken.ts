import { TokenKey } from "src/app/services/storage/StorageKeys";

export const getJwtToken = () => localStorage[TokenKey];