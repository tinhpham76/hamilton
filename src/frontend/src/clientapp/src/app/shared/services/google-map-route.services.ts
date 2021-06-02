import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.services';
import { KeyValuePair } from '../models/key-value-pair.model';
import { Base } from '../models/base.model';
import { FindPlace } from '../models/google-map/places/place-search/find-place/find-place.model';
import { Direction } from '../models/google-map/routes/direction/direction.model';

@Injectable({ providedIn: 'root' })
export class GoogleMapRouteService extends BaseService {

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
    Direction(origin: string,
        destination: string,
        mode: string = 'driving',
        waypoints: string = null,
        alternatives: boolean = null,
        avoid: string = null,
        language: string = 'vi',
        units: string = null,
        region: string = 'vni'): Observable<Base<Direction>> {
        var params: KeyValuePair[] = []

        if (origin)
            params.push({ key: 'origin', value: origin })

        if (destination)
            params.push({ key: 'destination', value: destination })

        if (mode)
            params.push({ key: 'mode', value: mode })

        if (waypoints)
            params.push({ key: 'waypoints', value: waypoints })

        if (alternatives)
            params.push({ key: 'alternatives', value: alternatives })

        if (avoid)
            params.push({ key: 'avoid', value: avoid })

        if (units)
            params.push({ key: 'units', value: units })

        if (region)
            params.push({ key: 'region', value: region })

        if (language)
            params.push({ key: 'language', value: language })

        return this.http.get<Base<Direction>>(this.GetUrl(this._baseUrl, 'apis/googlemap/routes/directions', params), { headers: this.headers })
            .pipe(
                catchError(this.handleError<Base<Direction>>('google map direction api')));
    }
}