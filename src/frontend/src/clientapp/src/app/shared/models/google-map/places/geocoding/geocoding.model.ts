import { Geometry } from "../geometry.model"
import { AddressComponent } from "../address-component.model"
import { PlusCode } from "../plus-code.mode"

export class GeoCoding {
    address_components: AddressComponent[]
    formatted_address: string
    geometry: Geometry
    place_id: string
    plus_code: PlusCode
    types: string[]
}