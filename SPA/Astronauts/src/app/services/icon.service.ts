import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class IconService {
  getFontAwesomeSocialMediaIconClassesFromLink(link: string): string 
  {
    link = link.toLocaleLowerCase();

    if (/facebook\.com/i.test(link)) 
        return 'fa-brands fa-facebook';
    else if (/twitter\.com/i.test(link)) 
        return 'fa-brands fa-twitter';
    else if (/youtube\.com/i.test(link)) 
        return 'fa-brands fa-youtube';
    else if (/tiktok\.com/i.test(link)) 
        return 'fa-brands fa-tiktok';
    else if (/linkedin\.com/i.test(link))
        return 'fa-brands fa-linkedin';
    else if (/instagram\.com/i.test(link)) 
      return 'fa-brands fa-instagram';
    else
        return 'fa-solid fa-ellipsis'; 
  }
}
