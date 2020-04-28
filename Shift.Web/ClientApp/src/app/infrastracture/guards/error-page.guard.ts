import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { Observable } from "rxjs";
import { Store, select } from "@ngrx/store";
import { AppState, selectIsErrorOccurs } from "src/app/core/store/app/app.state";
import { tap } from "rxjs/operators";
import { RootPage } from "src/app/infrastracture/config";

@Injectable()
export class ErrorPageGuard implements CanActivate {
    private isErrorOccurs$: Observable<boolean>;

    constructor(private appStore: Store<AppState>, private router: Router) {
        this.isErrorOccurs$ = this.appStore.pipe(select(selectIsErrorOccurs));
    }

    canActivate() {
        return this.isErrorOccurs$.pipe(
            tap(isError => {
                if(!isError) {
                    this.router.navigate([RootPage]);
                }
            })
        )
    }
}