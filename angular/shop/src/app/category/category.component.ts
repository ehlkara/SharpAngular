import { Component, OnInit } from '@angular/core';
import { Category } from './category';
import { HttpClient } from '@angular/common/http';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css'],
  providers: [CategoryService]
})
export class CategoryComponent implements OnInit {

  constructor(private http: HttpClient, private categoryService: CategoryService) { }

  title = "Category List"

  categories!: Category[];

  ngOnInit(): void {
    this.categoryService.getcategories().subscribe(data => {
      this.categories = data
    })
  }
}
