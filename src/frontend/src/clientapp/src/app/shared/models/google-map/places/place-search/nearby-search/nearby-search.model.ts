import { Geometry } from "../../geometry.model"
import { OpeningHour } from "../../opening-hours.model"
import { Photo } from "../../photo.model"
import { PlusCode } from "../../plus-code.mode"

export class NearbySearch{
    business_status: string
    geometry: Geometry
    icon: string
    name: string
    opening_hours: OpeningHour
    photos: Photo[]
    place_id: string
    plus_code: PlusCode
    price_level: number
    rating: number
    reference: string
    scope:string
    types: string[]
    user_ratings_total: number
    vicinity: string
}