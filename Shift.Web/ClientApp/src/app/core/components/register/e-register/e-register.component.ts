import { Component, EventEmitter, Output } from "@angular/core";

@Component({
    selector: 'pac-e-register',
    templateUrl: './e-register.component.html',
    styleUrls: ['./e-register.component.scss'],
})
export class ERegisterComponent {
    @Output()
    public resetTargetType: EventEmitter<any> = new EventEmitter();

    public resetTarget() {
        this.resetTargetType.emit();
    }
}