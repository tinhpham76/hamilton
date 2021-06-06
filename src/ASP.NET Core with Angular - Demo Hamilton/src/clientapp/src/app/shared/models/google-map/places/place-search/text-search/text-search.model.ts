import { Geometry } from "../../geometry.model"
import { OpeningHour } from "../../opening-hours.model"
import { Photo } from "../../photo.model"
import { PlusCode } from "../../plus-code.mode"

export class TextSearch{
    business_status: string
    formatted_address: string
    geometry: Geometry
    icon: string
    opening_hours: OpeningHour[]
    photos: Photo[]
    place_id: string
    plus_code: PlusCode
    rating: number
    reference: string
    types: string[]
    user_ratings_total: number
}