import { Component, OnInit } from '@angular/core';
import { Intent } from '../../models/intents.model';
import { IntentsDataService } from '../../services/intents/intents-data.service';


interface ExtendedIntent extends Intent {
  categoryDescription?: string;
}

@Component({
  selector: 'app-invited',
  templateUrl: './invited.component.html',
  styleUrls: ['./invited.component.scss']
})
export class InvitedComponent implements OnInit {
  invitedIntents: ExtendedIntent[] = [];
  noInvitedMessage: string = '';

  categoryDescriptions: { [key: number]: string } = {
    0: 'Undefined',
    1: 'Painters',
    2: 'Interior Painters',
    3: 'General Building Work',
    4: 'Home Renovations',
  };

  constructor(private intentsDataService: IntentsDataService) { }

  ngOnInit(): void {
    this.loadInvitedIntents();
  }

  loadInvitedIntents(): void {
    this.intentsDataService.getIntentsByStatus(0).subscribe({
      next: (intents) => {
        if (intents && intents.length > 0) {          
          this.invitedIntents = intents.map(intent => ({
            ...intent,
            categoryDescription: this.categoryDescriptions[intent.category]
          }));
        } else {
          this.noInvitedMessage = 'No records found.';
        }
      },
      error: (error) => {
        console.error('Error fetching intents:', error);
        this.noInvitedMessage = 'Error fetching records.';
      }
    });
  }

  acceptIntent(intentId: string): void {
    this.intentsDataService.acceptIntent(intentId).subscribe({
      next: () => {        
        this.loadInvitedIntents();
      },
      error: (error) => {
        console.error('Error accepting intent:', error);
      }
    });
  }

  declineIntent(intentId: string): void {
    this.intentsDataService.declineIntent(intentId).subscribe({
      next: () => {
        this.loadInvitedIntents();
      },
      error: (error) => {
        console.error('Error declining intent:', error);
      }
    });
  }
}