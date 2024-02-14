import { Component, OnInit } from '@angular/core';
import { IntentsDataService } from '../../services/intents/intents-data.service';

@Component({
  selector: 'app-intents',
  templateUrl: './intents.component.html',
  styleUrls: ['./intents.component.scss']
})
export class IntentsComponent implements OnInit {
  currentTab: string = 'invited'; 

  constructor(private intentsDataService: IntentsDataService) { }

  ngOnInit(): void {
    this.updateTab('invited'); 
  }

  updateTab(tab: string): void {
    this.currentTab = tab; 
  }
}