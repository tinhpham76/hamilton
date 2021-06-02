import { MatchedSubstring } from "../matched-substring.model"
import { StructuredFormatting } from "../structured-formatting.model"
import { Term } from "../term.model"

export class PlaceAutocomplete {
    description: string
    matched_substrings: MatchedSubstring[]
    place_id: string
    reference: string
    structured_formatting: StructuredFormatting
    terms: Term[]
    types: string[]
}