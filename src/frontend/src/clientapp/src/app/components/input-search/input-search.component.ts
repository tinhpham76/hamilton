import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from "@angular/core";
import { NgbTypeahead } from "@ng-bootstrap/ng-bootstrap";
import { merge, Observable, OperatorFunction, Subject } from "rxjs";
import { debounceTime, distinctUntilChanged, filter, map } from "rxjs/operators";

@Component({
  selector: 'input-search',
  templateUrl: './input-search.component.html',
  styleUrls: ['./input-search.component.scss']
})

export class InputSearchComponent {
  @Input() id: string = 'typeahead'
  @Input() label: string = ''
  @Input() placeholder: string = ''
  @Input() type: string = ''
  @Input() width: string = '200px'

  @Input() states: string[] = []
  @Output() newValueEvent = new EventEmitter<string>();

  @ViewChild('instance', { static: true }) instance: NgbTypeahead
  focus = new Subject<string>()
  click = new Subject<string>()

  search: OperatorFunction<string, readonly string[]> = (text$: Observable<string>) => {
    const debouncedText$ = text$.pipe(debounceTime(200), distinctUntilChanged());
    const clicksWithClosedPopup$ = this.click.pipe(filter(() => !this.instance.isPopupOpen()));
    const inputFocus$ = this.focus;

    return merge(debouncedText$, inputFocus$, clicksWithClosedPopup$).pipe(
      map(term => this.states)
    );
  }

  value(term: string): void {
    this.newValueEvent.emit(term)
  }
}