import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { AddContactComponent } from './add-contact/add-contact.component';
import { EditContactComponent } from './edit-contact/edit-contact.component';
import { ContactDetailsComponent } from './contact-details/contact-details.component';
import { SearchContactComponent } from './search-contact/search-contact.component';

const routes: Routes = [
    {path: '', component: IndexComponent },
    {path: 'addContact', component: AddContactComponent },
    {path: 'editContact/:id', component: EditContactComponent },
    {path: 'contactDetails/:id', component: ContactDetailsComponent },
    {path: 'searchContact/:tag', component: SearchContactComponent },
    {path: '**', redirectTo: '', pathMatch: 'full'}     
  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }

  