import { HttpClientJsonpModule, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { GoogleMapsModule } from '@angular/google-maps';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './footer/fotter.component';
import { GoogleMapsComponent } from './components/google-maps/google-maps.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { InputSearchComponent } from './components/input-search/input-search.component';
import { DatePickerComponent } from './components/date-picker/date-picker.component';
import { AccordionResultComponent } from './components/accordion-result/accordion-result.component';
import { DropdownSelectComponent } from './components/dropdown-select/dropdown-select.component';
import { HomeComponent } from './home/home.component';
import { DocsComponent } from './docs/docs.component';
import { ExampleComponent } from './example/example.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    FooterComponent,
    HomeComponent,
    DocsComponent,
    ExampleComponent,

    // Custom Component
    InputSearchComponent,
    DatePickerComponent,
    AccordionResultComponent,
    DropdownSelectComponent,
    GoogleMapsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    HttpClientJsonpModule,
    FormsModule,
    GoogleMapsModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
