import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarComponent } from './car/car.component';
import { GoogleMapsComponent } from './components/google-maps/google-maps.component';
import { HomeComponent } from './home/home.component';
import { HotelComponent } from './hotel/hotel.component';
import { RentalComponent } from './rental/rental.component';
import { TourComponent } from './tour/tour.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'hotel', component: HotelComponent },
  { path: 'rental', component: RentalComponent },
  { path: 'tour', component: TourComponent },
  { path: 'car', component: CarComponent },
  { path: 'google-maps', component: GoogleMapsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
