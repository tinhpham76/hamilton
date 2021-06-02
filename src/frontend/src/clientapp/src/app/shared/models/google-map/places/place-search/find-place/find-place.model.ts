import { Geometry } from "../../geometry.model"
import { OpeningHour } from "../../opening-hours.model"
import { Photo } from "../../photo.model"
import { PlusCode } from "../../plus-code.mode"

export class FindPlace{
    business_status: string
    formatted_address: string
    geometry: Geometry
    icon: string
    name: string
    opening_hours: OpeningHour[]
    photos: Photo[]
    place_id: string
    plus_code: PlusCode
    types: string[]
    rating: number
    user_ratings_total: number
}