import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AstronautSearchFormComponent } from '../astronaut-search-form/astronaut-search-form.component';
import { RouterLink } from '@angular/router';
import { TitleService } from '../../services/title.service';
import { Astronaut } from '../../interfaces/astronaut';

@Component({
  selector: 'app-astronaut',
  standalone: true,
  imports: [
    CommonModule,
    HttpClientModule,
    AstronautSearchFormComponent,
    RouterLink
  ],
  templateUrl: './astronaut.component.html',
  styleUrl: './astronaut.component.css',
})
export class AstronautComponent implements OnInit 
{
  httpClient = inject(HttpClient);
  titleService = inject(TitleService);

  astronautList: Array<Astronaut> = [];
  currentPage: number = 1;
  totalPages: number = 1;
  // pageSize: number = 5;
  totalCount: number = 0;
  hasNextPage: boolean = false;
  hasPreviousPage: boolean = false;
  nextPageUrl: string = '';
  previousPageUrl: string = '';

  params = {
    AstronautId: null,
    Nationality: null,
    Status: null,
    PageNumber: 1,
    PageSize: 5,
  }

  ngOnInit(): void {
    this.getAstronauts();
  }

  getUrl()
  {
    let url: string = `http://localhost:5000/api/Astronaut?PageNumber=${this.currentPage}&PageSize=${this.params.PageSize}`;

    if(this.params.AstronautId !== null && this.params.AstronautId !== "")
      url += `&AstronautId=${this.params.AstronautId}`;

    if(this.params.Nationality !== null && this.params.Nationality !== "")
      url += `&Nationality=${this.params.Nationality}`;

    if(this.params.Status !== null && this.params.Status !== "")
      url += `&Status=${this.params.Status}`;

      console.log(url)
    return url;
  }

  getAstronauts() {
    let apiUrl: string = this.getUrl();

    this.httpClient.get(apiUrl).subscribe((response: any) => {
      this.astronautList = response.data;
      this.currentPage = response.meta.currentPage;
      this.totalPages = response.meta.totalPages;
      this.hasPreviousPage = response.meta.hasPreviousPage;
      this.hasNextPage = response.meta.hasNextPage;
      this.totalCount = response.meta.totalCount;

      console.log(response);
    });
  }

  getPageNumbers(): number[] {
    return Array.from({ length: this.totalPages }, (_, i) => i + 1);
  }

  previousPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.getAstronauts();
    }
  }

  nextPage() {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
      this.getAstronauts();
    }
  }

  selectPage(pageNumber: number) {
    this.currentPage = pageNumber;
    this.getAstronauts();
  }

  handleSearchForm(formData: any): void {
    const { id, nationality, status } = formData;
    this.params.AstronautId = id;
    this.params.Nationality = nationality;
    this.params.Status = status;

    this.currentPage = 1;
  
    this.getAstronauts();
  }

  setAstronautDetailTitle(event: Event) {
    event.preventDefault();
    let title: string = 'Astronaut details';
    this.titleService.titleClicked.next(title);
    this.titleService.setSelectedTitleToLocalStorage(title);
  }
}
