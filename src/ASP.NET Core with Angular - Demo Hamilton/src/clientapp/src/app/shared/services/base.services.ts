import { Observable, of } from "rxjs";
import { environment } from "src/environments/environment";
import { KeyValuePair } from "../models/key-value-pair.model";

export abstract class BaseService {
    constructor() { }

    /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
    protected handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {

            // TODO: send the error to remote logging infrastructure
            console.error(error); // log to console instead

            // TODO: better job of transforming error for user consumption
            this.log(`${operation} failed: ${error.message}`);

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }


    protected log(message: string) {
        console.log(message)
    }

    protected GetUrl(baseUrl: string, path: string, params: KeyValuePair[]): string {
        var url = '';

        url += baseUrl + path

        if (params && params.length > 0) {
            url += !url.indexOf('?') ? '&' : '?'
            for (let index = 0; index < params.length; index++) {
                url += '&' + params[index].key + '=' + params[index].value
            }
        }

        url += '&key=' + environment.GOOGLE_MAP_API_KEY;

        return url;
    }
}

