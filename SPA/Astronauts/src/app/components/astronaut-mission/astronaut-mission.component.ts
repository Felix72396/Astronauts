import { Component, inject, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Mission } from '../../interfaces/mission';


@Component({
  selector: 'app-astronaut-mission',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './astronaut-mission.component.html',
  styleUrl: './astronaut-mission.component.css'
})
export class AstronautMissionComponent implements OnInit {
  @Input() id: number = 0;
  @Output() returnRocket: EventEmitter<void> = new EventEmitter<void>();
  
  triggerReturnRocket():void{
    this.returnRocket.emit();
  }
  
  missionList: Mission[] = [];

  httpClient = inject(HttpClient);

  getMissions(astronautId: number): void {
    let apiUrl: string = `http://localhost:5000/api/AstronautMission?AstronautId=${astronautId}`;
    this.httpClient.get(apiUrl).subscribe((response: any) => {
      this.missionList = response.data;
      console.log(this.missionList)
    });
  }

  ngOnInit(): void {
    this.getMissions(this.id);
  }

  currentAccordionIndex: number | null = null;

  toggleAccordion(index: number): void {
    if (this.currentAccordionIndex === index) {
      this.currentAccordionIndex = null; 
    } else {
      this.currentAccordionIndex = index; 
    }
  }

}
