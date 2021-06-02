import { Distance } from './distance.mode'
import { Duration } from './duration.model'
import { Location } from './location.model'
import { Polyline } from './polyline.model'

export class Step {
    travel_mode: string
    start_location: Location
    end_location: Location
    polyline: Polyline
    duration: Duration
    html_instructions: string
    distance: Distance
}