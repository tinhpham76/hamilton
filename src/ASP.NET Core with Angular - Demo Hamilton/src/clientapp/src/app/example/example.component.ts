import { Component } from '@angular/core';
import { MapDirectionsService } from '@angular/google-maps';
import { NgbProgressbarConfig } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccordionResult, AccordionResultValueEvent, ChildAccordionResult } from '../components/accordion-result/accordion-result.component';
import { Base } from '../shared/models/base.model';
import { Hamilton } from '../shared/models/hamilton/hamilton.model';
import { GoogleMapPlaceService } from '../shared/services/google-map-place.services';
import { GoogleMapRouteService } from '../shared/services/google-map-route.services';
import { HamiltonService } from '../shared/services/hamilton.services';

@Component({
  selector: 'app-example',
  templateUrl: './example.component.html',
  styleUrls: ['./example.component.scss']
})
export class ExampleComponent {
  // Google Map
  height: string = '500px'
  width: string = '600px'
  zoom: number = 10
  center: google.maps.LatLngLiteral = { lat: 10.8230989, lng: 106.6296638 }
  markerPositions: google.maps.LatLngLiteral[] = []
  directionsResults: Observable<google.maps.DirectionsResult | undefined>

  // Input Search 
  public inputLocations: InputLocation[] = [
    { id: 0, title: 'Origin', value: '', isAddButton: false, isRemoveButton: false, placeId: '' },
    { id: 1, title: 'Destination', value: '', isAddButton: false, isRemoveButton: false, placeId: '' }
  ]
  states: string[] = []

  // Show Result
  accordionResults: AccordionResult[] = []
  message: string = ''
  showResult: boolean = false
  value: number = 0

  constructor(private googleMapPlaceService: GoogleMapPlaceService,
    private mapDirectionsService: MapDirectionsService,
    private googleMapRouteService: GoogleMapRouteService,
    private hamiltonService: HamiltonService,
    config: NgbProgressbarConfig) {
    config.max = 1000;
    config.striped = true;
    config.animated = true;
    config.type = 'success';
    config.height = '2px';
  }

  addInputSearch() {
    this.inputLocations.push({
      id: this.inputLocations.length + 1,
      value: '',
      title: 'Destination',
      isAddButton: true,
      isRemoveButton: false,
      placeId: ''
    });

    for (let i = 1; i < this.inputLocations.length - 1; i++) {
      this.inputLocations[i].isAddButton = false
      this.inputLocations[i].isRemoveButton = true
    }
  }

  removeInputSearch(index: number) {
    if (this.inputLocations.length === 2)
      this.inputLocations.forEach(element => {
        element.isAddButton = true
      });
    this.inputLocations.splice(index, 1)

    this.addMarker()
    this.hamilton()
  }

  inputSearchEvent(term: string, index: number): void {
    this.accordionResults = []
    if (index === 1)
      this.inputLocations[index].isAddButton = true

    this.googleMapPlaceService.PlaceAutoComplete(term)
      .subscribe(response => {
        if (response.data) {
          var statesTemp: string[] = []
          response.data.forEach(element => {
            statesTemp.push(element.description)
            if (element.description === term) {
              this.inputLocations[index].value = element.description
              this.inputLocations[index].placeId = element.place_id
              this.addMarker()
            }
          });
          this.states = statesTemp
        }
      })
  }

  addMarker(): void {
    var markerPositionsTemp: google.maps.LatLngLiteral[] = []
    this.inputLocations.forEach(element => {
      this.googleMapPlaceService.PlaceDetail(element.placeId)
        .subscribe(response => {
          if (response.data) {
            markerPositionsTemp.push(
              {
                lat: response.data.geometry.location.lat,
                lng: response.data.geometry.location.lng
              })

            this.center = {
              lat: response.data.geometry.location.lat,
              lng: response.data.geometry.location.lng
            }
            this.zoom = 10
          }
        });
    });

    this.markerPositions = markerPositionsTemp
    this.states = []
    this.hamilton()
  }

  hamilton(range: number = 10000): void {
    this.value = 0
    var hamiltonRequestTemp: string[] = []

    if (this.inputLocations.length > 1) {
      for (let i = 0; i < this.inputLocations.length; i++) {
        if (this.inputLocations[i].title === 'Origin'
          && this.inputLocations[i].value)
          hamiltonRequestTemp.push(this.inputLocations[i].value)
        else if (this.inputLocations[i].title === 'Destination'
          && this.inputLocations[i].value)
          hamiltonRequestTemp.push(this.inputLocations[i].value)
      }
      var start = new Date().getTime();
      this.hamiltonService.FindHamiltonWithAddress(hamiltonRequestTemp, range)
        .subscribe(response => {
          var end = new Date().getTime();
          var total_time = (end - start) / 1000;
          if (response) {
            this.showAccordionResult(response, total_time)

            if (response.data)
              this.value = 1000
          }
        })
    }
  }

  showAccordionResult(result: Base<Hamilton[]>, time: number): void {
    if (result.error && result.error.message) {
      this.showResult = true
      this.message = result.error.message
      this.accordionResults = []
    }

    if (result.data && result.data.length > 0) {
      var accordionResultsTemp: AccordionResult[] = []
      this.showResult = true

      this.message = 'Find ' + result.data.length + ' directions' + ' (' + time + ' seconds)'

      for (let i = 0; i < result.data.length; i++) {
        var accordionResultTemp: AccordionResult = {
          id: i,
          title: 'Direction ' + (i + 1),
          shotDescription: result.data[i].distance.text,
          description: result.data[i].hamiltons.toString().replace(',', '|'),
          childAccordionResults: []
        }

        var childAccordionResults: ChildAccordionResult[] = []
        for (let j = 0; j < result.data[i].detail.length; j++) {
          childAccordionResults.push(
            {
              id: j,
              origin: result.data[i].detail[j].origin,
              destination: result.data[i].detail[j].destination,
              shotDescription: result.data[i].detail[j].distance.text,
              description: result.data[i].detail[j].summary,
              childAccordionResults: []
            }
          )
        }
        accordionResultTemp.childAccordionResults = childAccordionResults
        accordionResultsTemp.push(accordionResultTemp)
      }
      this.accordionResults = accordionResultsTemp
    }
  }

  directionEvent(terms: AccordionResultValueEvent): void {
    this.googleMapRouteService.Direction(terms.origin, terms.destination)
      .subscribe(response => {
        if (response.data)
          for (let i = 0; i < response.data.routes.length; i++) {
            for (let j = 0; j < response.data.routes[i].legs.length; j++) {
              for (let k = 0; k < response.data.routes[i].legs[j].steps.length; k++) {
                this.accordionResults[terms.index].childAccordionResults[terms.childIndex].childAccordionResults.push(
                  {
                    id: k,
                    origin: terms.origin,
                    destination: terms.destination,
                    description: response.data.routes[i].legs[j].steps[k].html_instructions,
                    shotDescription: response.data.routes[i].legs[j].steps[k].distance.text,
                    childAccordionResults: null
                  })
              }
            }
          }
      })

    const request: google.maps.DirectionsRequest = {
      origin: terms.origin,
      destination: terms.destination,
      travelMode: google.maps.TravelMode.DRIVING
    };
    this.directionsResults = this.mapDirectionsService.route(request).pipe(map(response => response.result));
  }
}
export interface InputLocation {
  id: number
  title: string
  value: string
  placeId: string
  isAddButton: boolean
  isRemoveButton: boolean
}

export interface HamiltonRequest {
  origin: string
  destinations: string[]
}