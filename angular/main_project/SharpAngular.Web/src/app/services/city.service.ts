import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { City } from '../models/city';
import { Photo } from '../models/photo';
import { AlertifyService } from './alertify.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(
    private httpClient: HttpClient,
    private alertifyService: AlertifyService,
    private router: Router
    ) { }
  path = "https://localhost:7073/api/";

  getCities(): Observable<City[]> {
    return this.httpClient.get<City[]>(this.path + "Cities/" + "get_cities");
  }
  getCityById(cityId: number): Observable<City> {
    return this.httpClient.get<City>(this.path + "Cities/" + "get_city/" + cityId);
  }

  getPhotosByCity(cityId: number): Observable<Photo[]> {
    return this.httpClient.get<Photo[]>(this.path + "Cities/" + "get_photo_city/" + cityId);
  }

  add(city) {
    this.httpClient.post(this.path + "Cities/" + "add_city", city).subscribe(data => {
      this.alertifyService.success("City added successfully!");
      this.router.navigateByUrl('/cityDetail/' + data['id']);
    });
  }
}
