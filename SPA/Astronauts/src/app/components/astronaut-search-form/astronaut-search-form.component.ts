import { Component, Output, Input, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule, FormControl, FormGroup } from '@angular/forms';
import { AstronautComponent } from '../astronaut/astronaut.component';

@Component({
  selector: 'app-astronaut-search-form',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, AstronautComponent],
  templateUrl: './astronaut-search-form.component.html',
  styleUrl: './astronaut-search-form.component.css'
})
export class AstronautSearchFormComponent {
  @Output() searchFormSubmitted = new EventEmitter<any>();
  @Input() totalCount: number = 0;

  searchForm: FormGroup = new FormGroup({
    id: new FormControl(""),
    nationality: new FormControl(""),
    status: new FormControl("")
  });

  submitForm() {
    const formData = this.searchForm.value;
    
    this.searchFormSubmitted.emit(formData);
    this.searchForm.reset();
  }
}
