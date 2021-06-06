import { AddressComponent } from "../address-component.model"
import { Geometry } from "../geometry.model"
import { OpeningHour } from "../opening-hours.model"
import { Photo } from "../photo.model"
import { PlusCode } from "../plus-code.mode"
import { Review } from "./review.model"

export class PlaceDetail{
    address_components: AddressComponent[]
    adr_address: string
    language: string
    formatted_address: string
    formatted_phone_number: string
    geometry: Geometry
    icon: string
    international_phone_number: string
    name: string
    place_id: string
    rating: number
    reference: string
    reviews: Review[]
    types: string[]
    url: string
    utc_offset: number
    vicinity: string
    website: string
    opening_hours: OpeningHour
    photos: Photo[]
    plus_code: PlusCode
    user_ratings_total: number
}