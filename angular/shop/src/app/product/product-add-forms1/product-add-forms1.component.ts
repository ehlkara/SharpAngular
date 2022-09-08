import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Category } from 'src/app/category/category';
import { CategoryService } from 'src/app/services/category.service';
import { Product } from '../product';

@Component({
  selector: 'app-product-add-forms1',
  templateUrl: './product-add-forms1.component.html',
  styleUrls: ['./product-add-forms1.component.css'],
  providers: [CategoryService]
})
export class ProductAddForms1Component implements OnInit {

  constructor(private categoryService: CategoryService) { }

  model: Product = new Product();
  categories!: Category[];

  ngOnInit(): void {
    this.categoryService.getcategories().subscribe(data => {
      this.categories = data
    });
  }

  add(form: NgForm) {
    console.log(form.value.name);
  }
}
