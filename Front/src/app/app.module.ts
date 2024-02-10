import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router'; 
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';


import { AppComponent } from './app.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { IntentsComponent } from './components/intents/intents.component';
import { IntentsDataService } from './services/intents/intents-data.service';


const routes: Routes = [
  { path: '', component: IntentsComponent } 
];

@NgModule({
  declarations: [
    AppComponent,
    IntentsComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    BrowserModule,
    NoopAnimationsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [IntentsDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
