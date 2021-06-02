import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PlaceAutocomplete } from '../shared/models/google-map/places/place-autocomplete/place-autocomplete.model';
import { GoogleMapPlaceService } from '../shared/services/google-map-place.services';

@Component({
  selector: 'app-rental',
  templateUrl: './rental.component.html',
  styleUrls: ['./rental.component.scss']
})
export class RentalComponent implements OnInit {
  // Display Google Map
  height: string = '720px'
  width: string = '1350px'
  zoom: number = 10
  center: google.maps.LatLngLiteral = { lat: 10.8230989, lng: 106.6296638 }

  // Marker
  markerPositions: google.maps.LatLngLiteral[] = []

  // Direction
  directionsResults: Observable<google.maps.DirectionsResult | undefined>

  states: string[] = []

  placesAutoComplete: PlaceAutocomplete[] = []

  constructor(private googleMapPlaceService: GoogleMapPlaceService) { }

  ngOnInit() {
  }

  inputSearchEvent(term: string): void {
    this.googleMapPlaceService.PlaceAutoComplete(term)
      .subscribe(response => {
        if (response.data) {
          var statesTemp: string[] = []
          response.data.forEach(element => {
            statesTemp.push(element.description)
            if (element.description === term) {
              this.addMarker(element.place_id)
            }
          });
          this.states = statesTemp
        }
      })
  }

  addMarker(term: string): void {
    this.googleMapPlaceService.PlaceDetail(term)
      .subscribe(response => {
        if (response.data) {
          this.markerPositions.push(
            { lat: response.data.geometry.location.lat, lng: response.data.geometry.location.lng })

          this.center = { lat: response.data.geometry.location.lat, lng: response.data.geometry.location.lng }
          this.zoom = 15
        }
      })
  }
}
