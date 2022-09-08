import { Component, OnInit } from '@angular/core';
import { Category } from './category';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  constructor() { }

  title = "Category List"
  categories : Category[] = [
    {id:1, name:"Electronic"},
    {id:2, name:"Computers"},
    {id:3, name:"Phones"},
    {id:4, name:"Music"},
    {id:5, name:"Drinks"}
  ]

  ngOnInit(): void {
  }

}
