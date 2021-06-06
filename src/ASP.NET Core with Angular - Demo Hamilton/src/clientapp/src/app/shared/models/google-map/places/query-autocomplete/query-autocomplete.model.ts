import { MatchedSubstring } from "../matched-substring.model"
import { StructuredFormatting } from "../structured-formatting.model"
import { Term } from "../term.model"

export class QueryAutocomplete {
    description: string
    matched_substrings: MatchedSubstring[]
    structured_formatting: StructuredFormatting
    terms: Term[]
    place_id: string
    reference: string
    types: string[]
}