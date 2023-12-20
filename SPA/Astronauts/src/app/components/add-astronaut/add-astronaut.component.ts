import { Component, inject } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { FormsModule, ReactiveFormsModule, FormControl, FormGroup, Validators } from '@angular/forms';
import { DataService } from '../../services/data.service';
import { HttpClient, HttpClientModule} from '@angular/common/http';



@Component({
  selector: 'app-add-astronaut',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, DatePipe, HttpClientModule],
  providers: [DatePipe, DataService, HttpClient, HttpClientModule],
  templateUrl: './add-astronaut.component.html',
  styleUrl: './add-astronaut.component.css'
})
export class AddAstronautComponent 
{
  datePipe = inject(DatePipe);
  data = inject(DataService);

  addForm: FormGroup = new FormGroup({
    firstName: new FormControl("", Validators.required),
    lastName: new FormControl("", Validators.required),
    nationality: new FormControl("", Validators.required),
    description: new FormControl(""),
    birthDate: new FormControl(this.datePipe.transform(new Date(), 'yyyy-MM-dd'), Validators.required),
    status: new FormControl("", Validators.required),
    photo: new FormControl(null)
  });

  postAstronaut(): void {

    if(this.addForm.valid){
      const formData = this.addForm.value;
      console.log(formData)
      this.data.postData(formData, "http://localhost:5000/api/Astronaut").subscribe(
        (response) => {
          alert(`Astronaut was added`);
          console.log(response);
          this.addForm.reset();
          const $file = document.querySelector("[type='file']") as HTMLInputElement;
          if($file) $file.value = "";
        },
        (err) => {
          if (err?.error?.errors) {
            if (err.error.errors.BirthDate && err.error.errors.BirthDate.length > 0) {
              alert(err.error.errors.BirthDate[0]);
            }
  
            if (err.error.errors.Description && err.error.errors.Description.length > 0) {
              alert(err.error.errors.Description[0]);
            }
          } else {
            alert("An error occurred while processing your request.");
          }
        }
      );
    }
    else{
      alert("Please, fill all the required fields.");
    }
  }

  imageUrl: string | ArrayBuffer | null = null;

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    const file: File | null = input?.files?.[0] || null;
  
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        this.imageUrl = reader.result as string;
      };
      reader.readAsDataURL(file);
    }
  }

  handleFileInput(event: any): void {
    const file: File = event.target.files[0];
    const reader = new FileReader();
  
    reader.onloadend = () => {
      const fileContent: ArrayBuffer | null = reader.result as ArrayBuffer;

      if (fileContent) {
        const uintArray = new Uint8Array(fileContent);
        const numArray = Array.from(uintArray); 
        const base64String = btoa(String.fromCharCode.apply(null, numArray));
        this.addForm.get('photo')?.setValue(base64String);
      }
    };
  
    reader.readAsArrayBuffer(file);
  }
}
