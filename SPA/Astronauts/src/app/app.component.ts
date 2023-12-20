import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet, RouterLink, Router } from '@angular/router';
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
  constructor
  (
    private titleService: TitleService,
    private router: Router
  ) {}

  title: string = this.titleService.getSelectedTitleFromLocalStorage()+"";

  ngOnInit() {
    console.log(this.title)
    if(this.title === "null"){
      this.title = "Welcome to Astronaut Project";
      this.router.navigate(['']);
    }

    this.titleService.titleClicked.subscribe((title: string) => {
      this.title = title;
    });
  }
}
