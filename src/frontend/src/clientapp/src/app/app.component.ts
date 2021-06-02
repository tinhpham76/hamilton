import { Component, OnInit } from '@angular/core';
import { GoogleMapPlaceService } from './shared/services/google-map-place.services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  constructor(private googleMapPlaceService: GoogleMapPlaceService) { }

  ngOnInit(): void {
    // this.googleMapPlaceService.FindPlace('DDaH GTVT')
    //   .subscribe(response =>{
    //     console.log(response)
    //   })

    // this.googleMapPlaceService.NearbySearch('-33.8670522,151.1957362', 1500, 'cruise','restaurant')
    //   .subscribe(response =>{
    //     console.log(response)
    //   })

    // this.googleMapPlaceService.TextSearch('Phân Hiệu ĐH GTVT')
    //   .subscribe(respone =>{
    //     console.log(respone)
    //   })

    // this.googleMapPlaceService.PlaceDetail('ChIJN1t_tDeuEmsRUsoyG83frY4')
    //   .subscribe(respone =>{
    //     console.log(respone)
    //   })

    // this.googleMapPlaceService.PlaceAutoComplete('ĐH GTVT CS2')
    //   .subscribe(response =>{
    //     console.log(response)
    //   })

    // this.googleMapPlaceService.QueryAutocomplete('ĐH GTVT CS2')
    //   .subscribe(response => {
    //     console.log(response)
    //   })

    // this.googleMapPlaceService.GeoCoding('ĐH GTVT CS2')
    //   .subscribe(response => {
    //     console.log(response)
    //   })
  }
}
