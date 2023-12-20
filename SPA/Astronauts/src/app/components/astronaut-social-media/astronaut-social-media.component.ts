import { Component, inject, Output, EventEmitter, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { SocialMedia } from '../../interfaces/social-media';
import { IconService } from '../../services/icon.service';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-astronaut-social-media',
  standalone: true,
  imports: [CommonModule, RouterLink],
  providers: [DataService, HttpClient, IconService],
  templateUrl: './astronaut-social-media.component.html',
  styleUrl: './astronaut-social-media.component.css'
})
export class AstronautSocialMediaComponent implements OnInit {
  @Output() returnRocket: EventEmitter<void> = new EventEmitter<void>();

  httpClient = inject(HttpClient);
  route = inject(ActivatedRoute);
  dataService = inject(DataService);
  icons = inject(IconService);

  socialMediaList: SocialMedia[] = [];
  astronautId: number = 0;
  
  triggerReturnRocket():void{
    this.returnRocket.emit();
  }

  getSocialMedia(astronautId: number): void {
    let apiUrl: string = `http://localhost:5000/api/SocialMedia?astronautId=${astronautId}`;
    this.dataService.getData(apiUrl).subscribe(
      (response) => {
        console.log(response);
        this.socialMediaList = response.data
      },
      (err) => {
        if(err?.error?.errors[0] !== undefined)
        {
          alert(err?.error?.errors[0])
        }
      }
    );
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
     this.astronautId = +params['id'];
     this.getSocialMedia(this.astronautId);
    });
  }

}
