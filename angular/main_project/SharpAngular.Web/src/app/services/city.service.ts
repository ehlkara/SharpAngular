import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'
import { City } from '../models/city';
import { Photo } from '../models/photo';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private httpClient: HttpClient) { }
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
}
