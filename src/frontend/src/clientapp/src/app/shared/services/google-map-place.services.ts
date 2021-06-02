import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.services';
import { KeyValuePair } from '../models/key-value-pair.model';
import { Base } from '../models/base.model';
import { FindPlace } from '../models/google-map/places/place-search/find-place/find-place.model';
import { NearbySearch } from '../models/google-map/places/place-search/nearby-search/nearby-search.model';
import { PlaceAutocomplete } from '../models/google-map/places/place-autocomplete/place-autocomplete.model';
import { QueryAutocomplete } from '../models/google-map/places/query-autocomplete/query-autocomplete.model';
import { GeoCoding } from '../models/google-map/places/geocoding/geocoding.model';
import { TextSearch } from '../models/google-map/places/place-search/text-search/text-search.model';
import { PlaceDetail } from '../models/google-map/places/place-detail/place-detail.model';

@Injectable({ providedIn: 'root' })
export class GoogleMapPlaceService extends BaseService {

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
    FindPlace(input: string,
        inputtype: string = 'textquery',
        language: string = 'vi',
        fields: string = null,
        locationbias: string = null): Observable<Base<FindPlace[]>> {
        var params: KeyValuePair[] = []

        if (input)
            params.push({ key: 'input', value: input })

        if (inputtype)
            params.push({ key: 'inputtype', value: inputtype })

        if (language)
            params.push({ key: 'language', value: language })

        if (fields)
            params.push({ key: 'fields', value: fields })

        if (locationbias)
            params.push({ key: 'locationbias', value: locationbias })

        return this.http.get<Base<FindPlace[]>>(this.GetUrl(this._baseUrl, 'apis/googlemap/places/findplacefromtext', params), { headers: this.headers })
            .pipe(
                catchError(this.handleError<Base<FindPlace[]>>('google map find place api')));
    }

    NearbySearch(location: string,
        radius: number = 10000,
        keyword: string = null,
        language: string = 'vi',
        name: string = null,
        type: string = null): Observable<Base<NearbySearch[]>> {
        var params: KeyValuePair[] = []

        if (location)
            params.push({ key: 'location', value: location })

        if (radius)
            params.push({ key: 'radius', value: radius })

        if (keyword)
            params.push({ key: 'keyword', value: keyword })

        if (language)
            params.push({ key: 'language', value: language })

        if (name)
            params.push({ key: 'name', value: name })

        if (type)
            params.push({ key: 'type', value: type })

        return this.http.get<Base<NearbySearch[]>>(this.GetUrl(this._baseUrl, 'apis/googlemap/places/nearbysearch', params), { headers: this.headers })
            .pipe(
                catchError(this.handleError<Base<NearbySearch[]>>('google map nearby search api')));
    }

    TextSearch(query: string,
        radius: number = null,
        region: string = 'vni',
        location: string = null,
        language: string = 'vi',
        type: string = null): Observable<Base<TextSearch[]>> {
        var params: KeyValuePair[] = []

        if (query)
            params.push({ key: 'query', value: query })

        if (location)
            params.push({ key: 'location', value: location })

        if (radius)
            params.push({ key: 'radius', value: radius })

        if (region)
            params.push({ key: 'region', value: region })

        if (language)
            params.push({ key: 'language', value: language })

        if (type)
            params.push({ key: 'type', value: type })

        return this.http.get<Base<TextSearch[]>>(this.GetUrl(this._baseUrl, 'apis/googlemap/places/textsearch', params), { headers: this.headers })
            .pipe(
                catchError(this.handleError<Base<TextSearch[]>>('google map text search api')));
    }

    PlaceDetail(place_id: string,
        language: string = 'vi',
        region: string = 'vni',
        sessiontoken: string = null,
        fields: string = null): Observable<Base<PlaceDetail>> {
        var params: KeyValuePair[] = []

        if (place_id)
            params.push({ key: 'place_id', value: place_id })

        if (region)
            params.push({ key: 'region', value: region })

        if (language)
            params.push({ key: 'language', value: language })

        if (fields)
            params.push({ key: 'fields', value: fields })

        if (sessiontoken)
            params.push({ key: 'sessiontoken', value: sessiontoken })

        return this.http.get<Base<PlaceDetail>>(this.GetUrl(this._baseUrl, 'apis/googlemap/places/details', params), { headers: this.headers })
            .pipe(
                catchError(this.handleError<Base<PlaceDetail>>('google map place detail api')));
    }

    PlaceAutoComplete(input: string,
        offset: number = null,
        radius: number = null,
        sessiontoken: string = null,
        origin: string = null,
        location: string = null,
        language: string = 'vi',
        types: string = null,
        components: string = null,
        strictbounds: string = null): Observable<Base<PlaceAutocomplete[]>> {
        var params: KeyValuePair[] = []

        if (input)
            params.push({ key: 'input', value: input })

        if (offset)
            params.push({ key: 'offset', value: offset })

        if (radius)
            params.push({ key: 'radius', value: radius })

        if (sessiontoken)
            params.push({ key: 'sessiontoken', value: sessiontoken })

        if (origin)
            params.push({ key: 'origin', value: origin })

        if (location)
            params.push({ key: 'location', value: location })

        if (language)
            params.push({ key: 'language', value: language })

        if (types)
            params.push({ key: 'types', value: types })

        if (components)
            params.push({ key: 'components', value: components })

        if (strictbounds)
            params.push({ key: 'strictbounds', value: strictbounds })


        return this.http.get<Base<PlaceAutocomplete[]>>(this.GetUrl(this._baseUrl, 'apis/googlemap/places/autocomplete', params), { headers: this.headers })
            .pipe(
                catchError(this.handleError<Base<PlaceAutocomplete[]>>('google map place auto complete api')));
    }

    QueryAutocomplete(input: string,
        offset: number = null,
        radius: number = null,
        location: number = null,
        language: string = 'vi'): Observable<Base<QueryAutocomplete[]>> {
        var params: KeyValuePair[] = []

        if (input)
            params.push({ key: 'input', value: input })

        if (offset)
            params.push({ key: 'offset', value: offset })

        if (radius)
            params.push({ key: 'radius', value: radius })

        if (location)
            params.push({ key: 'location', value: location })

        if (language)
            params.push({ key: 'language', value: language })

        return this.http.get<Base<QueryAutocomplete[]>>(this.GetUrl(this._baseUrl, 'apis/googlemap/places/queryautocomplete', params), { headers: this.headers })
            .pipe(
                catchError(this.handleError<Base<QueryAutocomplete[]>>('google map place query auto complete api')));
    }

    GeoCoding(address: string,
        components: string = null,
        bounds: string = null,
        language: string = 'vi',
        region: string = 'vni'): Observable<Base<GeoCoding[]>> {
        var params: KeyValuePair[] = []

        if (address)
            params.push({ key: 'address', value: address })

        if (components)
            params.push({ key: 'components', value: components })

        if (bounds)
            params.push({ key: 'bounds', value: bounds })

        if (location)
            params.push({ key: 'location', value: location })

        if (language)
            params.push({ key: 'language', value: language })

        if (region)
            params.push({ key: 'region', value: region })

        return this.http.get<Base<GeoCoding[]>>(this.GetUrl(this._baseUrl, 'apis/googlemap/geocode', params), { headers: this.headers })
            .pipe(
                catchError(this.handleError<Base<GeoCoding[]>>('google map place query auto complete api')));
    }
}