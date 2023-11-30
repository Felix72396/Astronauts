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
    this.titleService.titleClicked.next('Welcome to Astronaut Project');
  }

  setLoginTitle(event: Event) {
    event.preventDefault();
    this.titleService.titleClicked.next('Login');
  }

  setRegisterTitle(event: Event) {
    event.preventDefault();
    this.titleService.titleClicked.next('Register');
  }

  setAstronautTitle(event: Event) {
    event.preventDefault();
    this.titleService.titleClicked.next('Astronaut list');
  }

  setAstronautDetailTitle(event: Event) {
    event.preventDefault();
    this.titleService.titleClicked.next('Astronaut details');
  }

  setAddAstronautTitle(event: Event) {
    event.preventDefault();
    this.titleService.titleClicked.next('Add Astronaut');
  }

  setMissionsTitle(event: Event) {
    event.preventDefault();
    this.titleService.titleClicked.next('Missions done');
  }

  setSocialMediaTitle(event: Event) {
    event.preventDefault();
    this.titleService.titleClicked.next('Social media links');
  }
}
