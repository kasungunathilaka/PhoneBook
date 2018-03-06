import { Component, OnInit } from '@angular/core';
import { ContactDetails } from '../models/contact-details';
import { ContactService } from '../services/contact.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  contacts: ContactDetails[];
  constructor(private _contactService: ContactService) { }

  ngOnInit() {
    this.getAllContacts();
  }

  getAllContacts(): void {
    this._contactService.getAllContacts()
        .subscribe(contacts => {
          this.contacts = contacts;
        }),
        error => {
          console.log(error);
        };        
  }

}
