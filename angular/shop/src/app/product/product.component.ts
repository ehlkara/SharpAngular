import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor() { }

  title = "Product List"
  products : any[] = [
    {id:1, name: "NoteBook", price:25000, categoryId:1, description:"HP Pavilion Gaming"},
    {id:2, name: "Mouse", price:25, categoryId:2, description:"Microsoft mouse"}
  ] 

  ngOnInit(): void {
  }

}
