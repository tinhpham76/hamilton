import { Component, Input } from "@angular/core";

@Component({
    selector: 'dropdown-select',
    templateUrl: './dropdown-select.component.html',
    styleUrls: ['./dropdown-select.component.scss']
})

export class DropdownSelectComponent {
    @Input() width: string = '200px'
    @Input() label: string = ''
}