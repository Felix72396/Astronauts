import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AstronautComponent } from './components/astronaut/astronaut.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AstronautDetailComponent } from './components/astronaut-detail/astronaut-detail.component';
import { AddAstronautComponent } from './components/add-astronaut/add-astronaut.component';
import { MissionComponent } from './components/mission/mission.component';
import { SocialMediaComponent } from './components/social-media/social-media.component';


export const routes: Routes = [
    {path: "", title: "Home", component: HomeComponent},
    {path: "login", title: "Login", component: LoginComponent},
    {path: "register", title: "Register", component: RegisterComponent},
    {path: "astronaut", title: "Astronaut", component: AstronautComponent},
    {path: "astronaut-detail/:id", title: "Astronaut Detail", component: AstronautDetailComponent},
    {path: "mission/:id", title: "Mission", component: MissionComponent},
    {path: "social-media/:id", title: "Social Media", component: SocialMediaComponent},
    {path: "add-astronaut", title: "Add astronaut", component: AddAstronautComponent},
];
