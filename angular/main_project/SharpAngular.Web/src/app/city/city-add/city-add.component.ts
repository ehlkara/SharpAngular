import { Component, OnInit } from '@angular/core';
import { CityService } from 'src/app/services/city.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms'
import { City } from 'src/app/models/city';
import { Editor } from 'ngx-editor';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-city-add',
  templateUrl: './city-add.component.html',
  styleUrls: ['./city-add.component.css'],
  providers: [CityService]
})
export class CityAddComponent implements OnInit {

  constructor(
    private cityService: CityService,
    private formBuilder: FormBuilder,
    private authService: AuthService
  ) { }
  editor: Editor | undefined;
  html = '';
  city!: City;
  cityAddForm!: FormGroup;

  createCityForm() {
    this.cityAddForm = this.formBuilder.group(
      {
        name: ["", Validators.required],
        description: ["", Validators.required]
      }
    )
  }

  ngOnInit(): void {
    this.createCityForm();
    this.editor = new Editor();
  }

  add() {
    if (this.cityAddForm.valid) {
      this.city = Object.assign({}, this.cityAddForm.value)
      //Todo
      this.city.userId = this.authService.getCurrentUserId();
      this.cityService.add(this.city);
    }
  }
  ngOnDestroy(): void {
    this.editor?.destroy();
  }
}
