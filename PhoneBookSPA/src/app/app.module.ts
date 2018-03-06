import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms' 

import { AppComponent } from './app.component';
import { IndexComponent } from './index/index.component';
import { AddContactComponent } from './add-contact/add-contact.component';

import { AppRoutingModule } from './app-routing.module';

import { ContactService } from './services/contact.service'
import { ConfigurationService } from './services/configurations.service';


@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    AddContactComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpModule,
    FormsModule
  ],
  providers: [
    ContactService,
    ConfigurationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
