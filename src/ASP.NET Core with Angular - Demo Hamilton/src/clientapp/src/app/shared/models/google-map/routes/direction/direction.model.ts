import { Bound } from "./bound.model";
import { GeocodedWaypoint } from "./geocoded-waypoint.model";
import { OverviewPolyline } from "./overview-polyline.model";
import { Route } from "./route.model";

export class Direction{
    geocoded_waypoints: GeocodedWaypoint[]
    status: string
    error_message: string
    routes: Route[]
    copyrights: string
    overview_polyline: OverviewPolyline
    available_travel_modes: string[]
    waypoint_order: number[]
    bounds: Bound
}