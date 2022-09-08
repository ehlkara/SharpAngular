import { Component, OnInit } from '@angular/core';
import { Product } from './product';
import { AlertifyService } from '../services/alertify.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
  // providers:[AlertifyService]
})
export class ProductComponent implements OnInit {

  constructor(private alertifyService:AlertifyService) { }

  title = "Product List"
  filterText = ""
  products : Product[] = [

  ] 

  ngOnInit(): void {
  }

  addToCart(product: { name: string; }) {
    this.alertifyService.success(product.name + " added")
  }
}
