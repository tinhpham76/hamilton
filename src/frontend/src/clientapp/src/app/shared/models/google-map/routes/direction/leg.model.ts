import { Location } from "./location.model";
import { Distance } from "./distance.mode";
import { Duration } from "./duration.model";
import { Step } from "./step.model";

export class Leg{
    steps: Step[]
    duration: Duration
    distance: Distance
    start_location: Location
    end_location: Location
    start_address: string
    end_address: string
}