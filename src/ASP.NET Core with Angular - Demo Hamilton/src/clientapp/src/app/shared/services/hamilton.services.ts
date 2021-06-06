import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.services';
import { KeyValuePair } from '../models/key-value-pair.model';
import { Base } from '../models/base.model';
import { Hamilton } from '../models/hamilton/hamilton.model';
import { Location } from '../models/hamilton/location.model';
import { PlaceId } from '../models/hamilton/place-id.model';

@Injectable({ providedIn: 'root' })
export class HamiltonService extends BaseService {

    private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    private _baseUrl: string;

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') baseUrl: string) {
        super();
        this._baseUrl = baseUrl;
    }

    /** GET */
    FindHamiltonWithAddress(locations: string[], range: number): Observable<Base<Hamilton[]>> {
        var params: KeyValuePair[] = []

        params.push({ key: 'range', value: range })

        var locationParam = '';

        for (let index = 0; index < locations.length; index++)
            locationParam += locations[index] + '|'

        params.push({ key: 'locations', value: locationParam })

        return this.http.get<Base<Hamilton[]>>(this.GetUrl(this._baseUrl, 'apis/hamilton/findhamilton', params), { headers: this.headers })
            .pipe(
                catchError(this.handleError<Base<Hamilton[]>>('hamilton api')));
    }

    FindHamiltonWithLocation(locations: Location[], range: number): Observable<Base<Hamilton[]>> {
        var params: KeyValuePair[] = []

        params.push({ key: 'range', value: range })

        var locationParam = '';

        for (let index = 0; index < locations.length; index++)
            locationParam += locations[index].lat + ',' + locations[index].lng + '|'

        params.push({ key: 'locations', value: locationParam })

        return this.http.get<Base<Hamilton[]>>(this.GetUrl(this._baseUrl, 'apis/hamilton/findhamilton', params), { headers: this.headers })
            .pipe(
                catchError(this.handleError<Base<Hamilton[]>>('hamilton api')));
    }

    FindHamiltonWithPlaceId(locations: PlaceId[], range: number): Observable<Base<Hamilton[]>> {
        var params: KeyValuePair[] = []

        params.push({ key: 'range', value: range })

        var locationParam = '';

        for (let index = 0; index < locations.length; index++)
            locationParam += 'place_id:' + locations[index].place_id + '|'

        params.push({ key: 'locations', value: locationParam })

        return this.http.get<Base<Hamilton[]>>(this.GetUrl(this._baseUrl, 'apis/hamilton/findhamilton', params), { headers: this.headers })
            .pipe(
                catchError(this.handleError<Base<Hamilton[]>>('hamilton api')));
    }
}