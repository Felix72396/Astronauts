import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule, FormControl, FormGroup, Validators } from '@angular/forms';
import { SocialMedia } from '../../interfaces/social-media';
import { ActivatedRoute } from '@angular/router';
import { DataService } from '../../services/data.service';
import { IconService } from '../../services/icon.service';

@Component({
  selector: 'app-social-media',
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule, ReactiveFormsModule],
  providers: [HttpClient, DataService, IconService],
  templateUrl: './social-media.component.html',
  styleUrl: './social-media.component.css'
})
export class SocialMediaComponent implements OnInit {
  http = inject(HttpClient);
  route = inject(ActivatedRoute);
  data = inject(DataService);
  icons = inject(IconService);

  socialMediaList: SocialMedia[] = [];
  astronautId: number = 0;

  isEditing: boolean = false;
  editableRow: number | null = null;

  addForm: FormGroup = new FormGroup({
    astronautId: new FormControl(""),
    description: new FormControl("", Validators.required),
    link: new FormControl("", Validators.required),
  });



  getSocialMedia(astronautId: number): void {
    let apiUrl: string = `http://localhost:5000/api/SocialMedia?astronautId=${astronautId}`;
    this.data.getData(apiUrl).subscribe(
      (response) => {
        console.log(response);
        this.socialMediaList = response.data
      },
      (err) => {
        if (err?.error?.errors[0] !== undefined) {
          alert(err?.error?.errors[0]);
        }
      }
    );
  }

  postSocialMedia(): void {
    if (this.addForm.valid) {
      const formData = this.addForm.value;
      this.data.postData(formData, "http://localhost:5000/api/SocialMedia").subscribe(
        (response) => {
          // alert(`Social media link was added`);
          this.addForm.reset();
          this.getSocialMedia(this.astronautId);
        },
        (err) => {
          if (err?.error?.errors) {
            if (err.error.errors.Description && err.error.errors.Description.length > 0) {
              alert(err.error.errors.Description[0]);
            }

            if (err.error.errors.Link && err.error.errors.Link.length > 0) {
              alert(err.error.errors.Link[0]);
            }
          } else {
            alert("An error occurred while processing your request.");
          }
        }
      );
    }
    else {
      alert("Please, fill all the required fields.");
    }
  }

  deleteSocialMedia(id: Number): void {
    let ok = confirm("Are you sure you want to delete this link?");
    if (!ok) return;

    this.data.deleteData(`http://localhost:5000/api/SocialMedia/${id}`).subscribe(
      (response) => {
        console.log(response);
        // alert(`Social media link was deleted`);
        this.getSocialMedia(this.astronautId);
      },
      (err) => {
        console.error(err);
        alert('Error occurred while deleting social media link');
      }
    );
  }

  updateSocialMedia(id: number, newData: any): void {
    this.data.updateData(newData, `http://localhost:5000/api/SocialMedia/${id}`).subscribe(
      (response) => {
        console.log(response);
        alert(`Social media link was updated`);
        this.getSocialMedia(this.astronautId);
      },
      (err) => {
        console.error(err);
        alert('Error occurred while updating social media link');
      }
    );
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.astronautId = +params['id'];
      this.getSocialMedia(this.astronautId);
      this.addForm.get('astronautId')?.setValue(this.astronautId);
    });
  }

  toggleEditable(row: number): void {
    if (this.editableRow !== null && this.editableRow !== row) {
      this.isEditing = false;
    }
    this.editableRow = this.editableRow === row ? null : row;
    this.isEditing = this.editableRow !== null;
  }

  confirmEdit(id: number) {
    this.isEditing = false;
    this.editableRow = null;
  }

  cancelEdit() {
    this.isEditing = false;
    this.editableRow = null;
  }
}
