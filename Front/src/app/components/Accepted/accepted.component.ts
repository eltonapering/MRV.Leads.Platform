import { Component, OnInit } from '@angular/core';
import { Intent } from '../../models/intents.model';
import { IntentsDataService } from '../../services/intents/intents-data.service';

interface ExtendedIntent extends Intent {
  categoryDescription?: string;
}
@Component({
  selector: 'app-accepted',
  templateUrl: './accepted.component.html',
  styleUrls: ['./accepted.component.scss']
})
export class AcceptedComponent implements OnInit {
  acceptedIntents: ExtendedIntent[] = [];
  noAcceptedMessage: string = '';

  categoryDescriptions: { [key: number]: string } = {
    0: 'Undefined',
    1: 'Painters',
    2: 'Interior Painters',
    3: 'General Building Work',
    4: 'Home Renovations',
  };

  constructor(private intentsDataService: IntentsDataService) { }

  ngOnInit(): void {
    this.loadAcceptedIntents(); 
  }

  loadAcceptedIntents(): void {    
    this.intentsDataService.getIntentsByStatus(1).subscribe({
      next: (intents) => {
        if (intents && intents.length > 0) {          
          this.acceptedIntents = intents.map(intent => ({
            ...intent,
            categoryDescription: this.categoryDescriptions[intent.category]
          }));
        } else {
          this.noAcceptedMessage = 'No records found.';
        }
      },
      error: (error) => {
        console.error('Error fetching accepted:', error);
        this.noAcceptedMessage = 'Error fetching records.';
      }
    });
  }
}