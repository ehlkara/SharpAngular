import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Product } from '../product/product';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators'

@Injectable()
export class ProductService {

  constructor(private http: HttpClient) { }

  path = "http://localhost:3000/products"

  getProducts(categoryId: number): Observable<Product[]> {
    return this.http.get<Product[]>(this.path + "?categoryId=" + categoryId).pipe(
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  handleError(err: HttpErrorResponse) {
    let errorMessage = ''
    if (err.error instanceof ErrorEvent) {
      errorMessage = 'Something wrong ' + err.error.message
    } else {
      errorMessage = 'System Error'
    }
    return throwError(errorMessage);
  }
}
