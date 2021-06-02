import { Period } from "./period.model"

export class OpeningHour{
    open_now: boolean
    periods: Period[]
    weekday_text: string[]
}