import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { AddContactComponent } from './add-contact/add-contact.component';

const routes: Routes = [
    {path: '', component: IndexComponent },
    {path: 'addContact', component: AddContactComponent },
    {path: '**', redirectTo: '', pathMatch: 'full'}     
  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }