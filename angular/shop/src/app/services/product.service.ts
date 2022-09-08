import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Product } from '../product/product';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators'

@Injectable()
export class ProductService {

  constructor(private http: HttpClient) { }

  path = "http://localhost:3000/products"

  getProducts(categoryId: number): Observable<Product[]> {
    let newPath = this.path;
    if (categoryId) {
      newPath += "?categoryId=" + categoryId
    }

    return this.http.get<Product[]>(newPath).pipe(
      tap(data => console.log(JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  addProduct(product: Product): Observable<Product> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Token'
      })
    }
    return this.http.post<Product>(this.path, product,httpOptions).pipe(
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
