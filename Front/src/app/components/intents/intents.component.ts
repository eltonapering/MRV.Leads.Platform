// intents.component.ts
import { Component, OnInit } from '@angular/core';
import { IntentsDataService } from '../../services/intents/intents-data.service';
import { Intent } from '../../models/intents.model';

@Component({
  selector: 'app-intents',
  templateUrl: './intents.component.html',
  styleUrls: ['./intents.component.scss']
})
export class IntentsComponent implements OnInit {
  intents: Intent[] = [];
  currentTab: 'invited' | 'accepted' = 'invited'; // Adiciona a variável currentTab para controlar a aba ativa

  constructor(private intentsDataService: IntentsDataService) { }

  ngOnInit(): void {
    this.loadIntents();
  }

  loadIntents(): void {
    // Carrega os intents de acordo com a aba selecionada
    const status = this.currentTab === 'invited' ? 0 : 1;
    this.intentsDataService.getIntentsByStatus(status).subscribe({
      next: (data) => this.intents = data,
      error: (error) => console.error(error)
    });
  }

  updateTab(tab: 'invited' | 'accepted'): void {
    // Atualiza a aba ativa e recarrega os intents
    this.currentTab = tab;
    this.loadIntents();
  }

  acceptIntent(intentId: string): void {
    // Envia a requisição para aceitar o intent
    this.intentsDataService.acceptIntent(intentId).subscribe({
      next: () => {
        // Recarrega os intents após aceitar
        this.loadIntents();
      },
      error: (error) => console.error(error)
    });
  }

  declineIntent(intentId: string): void {
    // Envia a requisição para recusar o intent
    this.intentsDataService.declineIntent(intentId).subscribe({
      next: () => {
        // Recarrega os intents após recusar
        this.loadIntents();
      },
      error: (error) => console.error(error)
    });
  }
}