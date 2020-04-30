import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class StorageService {
    public setValue(key: string, value: string) {
        localStorage.setItem(key, value);
    }

    public removeValue(key: string) {
        localStorage.removeItem(key);
    }

    public getValue(key: string) {
        return localStorage.getItem(key);
    }

    public clear() {
        localStorage.clear();
    }
}