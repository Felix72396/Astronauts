import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AstronautSearchFormComponent } from '../astronaut-search-form/astronaut-search-form.component';
import { RouterLink } from '@angular/router';
import { TitleService } from '../../services/title.service';

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
export class AstronautComponent implements OnInit {
  constructor(private titleService: TitleService) {}

  httpClient = inject(HttpClient);

  astronauts: Array<any> = [];
  currentPage: number = 1;
  totalPages: number = 1;
  pageSize: number = 5;
  totalCount: number = 0;
  hasNextPage: boolean = false;
  hasPreviousPage: boolean = false;
  nextPageUrl: string = '';
  previousPageUrl: string = '';

  apiUrl = `http://localhost:5000/api/Astronaut?PageNumber=1&PageSize=${this.pageSize}`;

  ngOnInit(): void {
    this.fetchAstronauts();
  }

  setAstronautDetailTitle(event: Event) {
    event.preventDefault();
    this.titleService.titleClicked.next('Astronaut details');
  }

  fetchAstronauts() {
    this.httpClient.get(this.apiUrl).subscribe((response: any) => {
      this.astronauts = response.data;
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
      this.apiUrl = `http://localhost:5000/api/Astronaut?PageNumber=${--this.currentPage}&PageSize=${this.pageSize}`;
      this.fetchAstronauts();
    }
  }

  nextPage() {
    if (this.currentPage < this.totalPages) {
      this.apiUrl = `http://localhost:5000/api/Astronaut?PageNumber=${++this.currentPage}&PageSize=${this.pageSize}`;
      this.fetchAstronauts();
    }
  }

  selectPage(pageNumber: number) {
    this.apiUrl = `http://localhost:5000/api/Astronaut?PageNumber=${pageNumber}&PageSize=${this.pageSize}`;
    this.fetchAstronauts();
  }

  handleSearchForm(formData: any): void {
    let params: string = '';

    const { id, nationality, status } = formData;

    if (id) params = `&AstronautId=${id}`;
    if (nationality) params += `&Nationality=${nationality}`;
    if (status) {
      params += `&Status=${status === 'active'}`;
    }

    this.apiUrl = `http://localhost:5000/api/Astronaut?PageNumber=1&PageSize=${this.pageSize}${params}`;

    if (params !== "")
      this.fetchAstronauts();

    if(this.totalCount === 0)
    {
      this.fetchAstronauts();
    }

  }
}
