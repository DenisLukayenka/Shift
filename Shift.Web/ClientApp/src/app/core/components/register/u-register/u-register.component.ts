import { Component, EventEmitter, Output } from "@angular/core";

@Component({
    selector: 'pac-u-register',
    templateUrl: './u-register.component.html',
    styleUrls: ['./u-register.component.scss'],
})
export class URegisterComponent {
    @Output()
    public resetTargetType: EventEmitter<any> = new EventEmitter();

    public resetTarget() {
        this.resetTargetType.emit();
    }
}