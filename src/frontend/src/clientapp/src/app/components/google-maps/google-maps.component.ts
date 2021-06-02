import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-google-maps',
  templateUrl: './google-maps.component.html',
  styleUrls: ['./google-maps.component.scss']
})
export class GoogleMapsComponent {
  @Input() height: string = '500px'
  @Input() width: string = '500px'
  @Input() zoom: number = 10
  @Input() center: google.maps.LatLngLiteral = { lat: 10.8230989, lng: 106.6296638 }

  @Input() markerPositions: google.maps.LatLngLiteral[] = []
  @Input() directionsResults: Observable<google.maps.DirectionsResult | undefined>

  apiLoaded: Observable<boolean>;

  // marker
  markerOptions: google.maps.MarkerOptions = { draggable: false };

  constructor(httpClient: HttpClient) {
    this.apiLoaded = httpClient.jsonp(`https://maps.googleapis.com/maps/api/js?key=${environment.GOOGLE_MAP_API_KEY}`, 'callback')
    .pipe(
      map(() => true),
      catchError(() => of(false)),
    );
  }

  moveMap(event: google.maps.MapMouseEvent) { }

  move(event: google.maps.MapMouseEvent) { }

  addMarker(event: google.maps.MapMouseEvent) { }
}
