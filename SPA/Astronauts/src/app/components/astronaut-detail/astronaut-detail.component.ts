import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Router, RouterLink } from '@angular/router';
import { Astronaut } from '../../interfaces/astronaut';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { AstronautMissionComponent } from '../astronaut-mission/astronaut-mission.component';
import { AstronautSocialMediaComponent } from '../astronaut-social-media/astronaut-social-media.component';


@Component({
  selector: 'app-astronaut-detail',
  standalone: true,
  imports: [CommonModule, HttpClientModule, AstronautMissionComponent, AstronautSocialMediaComponent, RouterLink],
  templateUrl: './astronaut-detail.component.html',
  styleUrl: './astronaut-detail.component.css'
})
export class AstronautDetailComponent implements OnInit 
{
  httpClient = inject(HttpClient);
  route = inject(ActivatedRoute);
  router = inject(Router);
  sanitizer = inject(DomSanitizer);

  astronautId: number = 0;
  age: number = 0;
  astronautImageUrl: SafeUrl | null = "";

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.astronautId = +params['id'];
      this.getAstronaut(this.astronautId);
  });
}

  astronaut: Astronaut = {
    id: 0,
    firstName: "",
    lastName: "",
    nationality: "",
    description: "",
    birthDate: new Date(0),
    status: false,
    photo: new Blob()
  };

  getAstronaut(astronautId: number): void {
    let apiUrl: string = `http://localhost:5000/api/Astronaut/${astronautId}`;
    this.httpClient.get(apiUrl).subscribe((response: any) => {
      this.astronaut = response.data;
      this.age = this.getAge(this.astronaut.birthDate);

      if(this.astronaut.photo)
        this.astronautImageUrl = this.getPhotoUrl(this.astronaut.photo);
    });
  }

  getAge(date: Date): number {
    const today = new Date();
    const birthDate = new Date(date);
    console.log(birthDate)
    const diffTime = Math.abs(today.getTime() - birthDate.getTime());
    const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
    const age = Math.floor(diffDays / 365.25); 
    return age;
  }

  getPhotoUrl(photo: Blob): SafeUrl{
    const byteCharacters = atob(photo+"");
    const byteNumbers = new Array(byteCharacters.length);
    
    for (let i = 0; i < byteCharacters.length; i++) {
      byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: 'image/jpeg' });
    const imageUrl = URL.createObjectURL(blob);
    
    return this.sanitizer.bypassSecurityTrustUrl(imageUrl);
  }

  takeOff(): void {
    const $rocket = document.querySelector('.astronaut-detail__rocket') as HTMLElement;
    if ($rocket) {
      $rocket.classList.add('take-off', 'boost');

      setTimeout(
        () => {
          $rocket.style.display = "none";

          const $missionContainer = document.querySelector('.astronaut-mission');

          if ($missionContainer) {
            $missionContainer.classList.remove('util-display-none');
          }

          const $socialMediaContainer = document.querySelector('.astronaut-social-media');

          if ($socialMediaContainer) {
            $socialMediaContainer.classList.add('util-display-none');
          }
        }, 1000);
    }
  }
 
  returnRocket(): void {
    const $rocket = document.querySelector('.astronaut-detail__rocket') as HTMLElement;
    if ($rocket) {
      setTimeout(() => $rocket.style.display = "block", 0)

      setTimeout(
        () => {
          $rocket.classList.remove('take-off', 'boost')
          const $missionContainer = document.querySelector('.astronaut-mission');

          if ($missionContainer) {
            $missionContainer.classList.add('util-display-none');
          }

          const $socialMediaContainer = document.querySelector('.astronaut-social-media');

          if ($socialMediaContainer) {
            $socialMediaContainer.classList.remove('util-display-none');
          }
        }, 10)
    }
  }

}
