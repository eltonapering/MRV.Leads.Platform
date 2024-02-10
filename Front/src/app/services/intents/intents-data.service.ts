// intents-data.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Intent } from '../../models/intents.model';

@Injectable({
  providedIn: 'root'
})
export class IntentsDataService {
  private apiUrl = 'https://localhost:7258'; // Substitua pela URL base da sua API

  constructor(private http: HttpClient) { }

  getIntentsByStatus(status: number): Observable<Intent[]> {
    return this.http.get<Intent[]>(`${this.apiUrl}/Intents/GetIntentsByStatus/${status}`);
  }

  acceptIntent(id: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/Intents/${id}/accept`, {});
  }

  declineIntent(id: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/Intents/${id}/decline`, {});
  }
}