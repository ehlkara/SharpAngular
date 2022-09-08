import { Component, OnInit } from '@angular/core';
import { Product } from './product';
import { AlertifyService } from '../services/alertify.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
  // providers:[AlertifyService]
})
export class ProductComponent implements OnInit {

  constructor(private alertifyService: AlertifyService, private http:HttpClient) { }

  title = "Product List"
  filterText = ""
  products!: Product[];
  path = "http://localhost:3000/products"

  ngOnInit(): void {
    this.http.get<Product[]>(this.path).subscribe(data => {
      this.products = data
    });
  }

  addToCart(product: { name: string; }) {
    this.alertifyService.success(product.name + " added")
  }
}
