import { Component, Input, OnInit } from "@angular/core";
import { NgbCalendar, NgbDateStruct } from "@ng-bootstrap/ng-bootstrap";

@Component({
    selector: 'date-picker',
    templateUrl: './date-picker.component.html',
    styleUrls: ['./date-picker.component.scss']
})

export class DatePickerComponent implements OnInit {
    @Input() title: string = ''

    model: NgbDateStruct

    constructor(private calendar: NgbCalendar) { }
    ngOnInit(): void {
        var dt = this.calendar.getToday()
        this.model = { year: dt.year, month: dt.month, day: dt.day }
    }
}