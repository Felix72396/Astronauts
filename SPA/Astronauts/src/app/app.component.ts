import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet, RouterLink } from '@angular/router';
import { HeaderComponent } from './components/header/header.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AstronautComponent } from './components/astronaut/astronaut.component';
import { AstronautDetailComponent } from './components/astronaut-detail/astronaut-detail.component';
import { AddAstronautComponent } from './components/add-astronaut/add-astronaut.component';
import { MissionComponent } from './components/mission/mission.component';
import { SocialMediaComponent } from './components/social-media/social-media.component';
import { FooterComponent } from './components/footer/footer.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule, RouterOutlet, RouterLink, 
    HeaderComponent, HomeComponent, LoginComponent, 
    RegisterComponent, AstronautComponent, AstronautDetailComponent, 
    AddAstronautComponent, MissionComponent, SocialMediaComponent,
    FooterComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title :string = 'Astronauts';
}
