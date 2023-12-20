import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { TitleService } from '../../services/title.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})

export class HeaderComponent {
  constructor(private titleService: TitleService) {}

  setHomeTitle(event: Event) {
    event.preventDefault();
    let title: string = 'Welcome to Astronaut Project';
    this.titleService.titleClicked.next(title);
    this.titleService.setSelectedTitleToLocalStorage(title);
  }

  // setLoginTitle(event: Event) {
  //   event.preventDefault();
  //   this.titleService.titleClicked.next('Login');
  // }

  // setRegisterTitle(event: Event) {
  //   event.preventDefault();
  //   this.titleService.titleClicked.next('Register');
  // }

  setAstronautTitle(event: Event) {
    event.preventDefault();
    let title: string = 'Astronaut list';
    this.titleService.titleClicked.next(title);
    this.titleService.setSelectedTitleToLocalStorage(title);
  }

  // setAstronautDetailTitle(event: Event) {
  //   event.preventDefault();
  //   this.titleService.titleClicked.next('Astronaut details');
  // }

  setAddAstronautTitle(event: Event) {
    event.preventDefault();
    let title: string = 'Add Astronaut';
    this.titleService.titleClicked.next(title);
    this.titleService.setSelectedTitleToLocalStorage(title);
  }

  // setMissionsTitle(event: Event) {
  //   event.preventDefault();
  //   this.titleService.titleClicked.next('Missions done');
  // }

  // setSocialMediaTitle(event: Event) {
  //   event.preventDefault();
  //   this.titleService.titleClicked.next('Social media links');
  // }
}
