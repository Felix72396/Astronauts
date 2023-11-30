import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet, RouterLink } from '@angular/router';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { TitleService } from './services/title.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule, RouterOutlet, RouterLink, 
    HeaderComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title: string = 'Welcome to Astronaut Project';

  constructor
  (
    private titleService: TitleService
  ) {}

  ngOnInit() {
    //title service
    this.titleService.titleClicked.subscribe((title: string) => {
      this.title = title;
    });
  }
}
