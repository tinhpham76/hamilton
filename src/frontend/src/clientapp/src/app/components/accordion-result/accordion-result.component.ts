import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
  selector: 'accordion-result',
  templateUrl: './accordion-result.component.html',
  styleUrls: ['./accordion-result.component.scss']
})

export class AccordionResultComponent {
  @Input() accordionResult: AccordionResult
  @Output() newValueEvent = new EventEmitter<AccordionResultValueEvent>();

  eventClick(origin: string, destination: string, index: number, childIndex: number): void {
    var temp: AccordionResultValueEvent = {
      origin: origin,
      destination: destination,
      index: index,
      childIndex: childIndex
    }
    this.newValueEvent.emit(temp)
  }
}

export interface AccordionResult {
  id: number
  title: string
  shotDescription: string
  description: string
  childAccordionResults: ChildAccordionResult[]
}
export interface ChildAccordionResult {
  id: number
  origin: string
  destination: string
  shotDescription: string
  description: string
  childAccordionResults: ChildAccordionResult[]
}

export interface AccordionResultValueEvent {
  origin: string,
  destination: string
  index: number
  childIndex: number
}