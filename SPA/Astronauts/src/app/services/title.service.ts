import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TitleService {
  titleClicked = new Subject<string>();

  private localStorageTitleKey: string = 'h1';

  setSelectedTitleToLocalStorage(title: string): void {
    localStorage.setItem(this.localStorageTitleKey, title);
  }

  getSelectedTitleFromLocalStorage(): string {
    return localStorage.getItem(this.localStorageTitleKey)+"";
  }

}
