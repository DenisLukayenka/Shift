import { Component, EventEmitter, Output } from "@angular/core";

@Component({
    selector: 'pac-g-register',
    templateUrl: './g-register.component.html',
    styleUrls: ['./g-register.component.scss'],
})
export class GRegisterComponent {
    @Output()
    public resetTargetType: EventEmitter<any> = new EventEmitter();

    public resetTarget() {
        this.resetTargetType.emit();
    }
}