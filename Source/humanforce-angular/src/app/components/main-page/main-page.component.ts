import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { SprintData } from 'src/app/shared/consts/sprints';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent {
  sprints = SprintData.sprints;
  form: FormGroup;
  sprintId: number;

  constructor(
    private fb: FormBuilder
  ){}

  ngOnInit(){
    this.form= this.fb.group({
      radio: new FormControl('')
    });

    this.form.get('radio').valueChanges.subscribe(v => this.sprintId = v);
  }

}
