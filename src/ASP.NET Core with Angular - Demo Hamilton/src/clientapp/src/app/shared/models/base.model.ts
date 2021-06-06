import {Error} from './error.model'

export class Base<T>{
    data: T
    error: Error
}