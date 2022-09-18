import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { CityComponent } from './city/city.component';
import { ValueArrayPipe } from './city/value-array.pipe';
import { CityDetailComponent } from './city/city-detail/city-detail.component';
import { CityAddComponent } from './city/city-add/city-add.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    CityComponent,
    ValueArrayPipe,
    CityDetailComponent,
    CityAddComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    NgxGalleryModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
