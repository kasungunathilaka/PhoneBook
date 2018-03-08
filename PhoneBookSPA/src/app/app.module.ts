import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { MatAutocompleteModule, MatInputModule } from '@angular/material';
import { TagInputModule } from 'ngx-chips';

import { AppComponent } from './app.component';
import { IndexComponent } from './index/index.component';
import { AddContactComponent } from './add-contact/add-contact.component';

import { ContactService } from './services/contact.service'
import { ConfigurationService } from './services/configurations.service';
import { ToastrServices } from './services/toastr.service';
import { EditContactComponent } from './edit-contact/edit-contact.component';
import { ContactDetailsComponent } from './contact-details/contact-details.component';
import { SearchContactComponent } from './search-contact/search-contact.component';


@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    AddContactComponent,
    EditContactComponent,
    ContactDetailsComponent,
    SearchContactComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule ,
    MatInputModule,
    MatAutocompleteModule,
    TagInputModule,
    CommonModule,   
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    ContactService,
    ConfigurationService,
    ToastrServices
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
