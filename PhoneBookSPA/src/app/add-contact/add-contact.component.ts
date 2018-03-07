import { Component, OnInit } from '@angular/core';
import { NgForm } from "@angular/forms";
import { ContactService } from '../services/contact.service';
import { ToastrServices } from '../services/toastr.service';
import { ContactDetails } from '../models/contact-details';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent implements OnInit {
  constructor(private _contactService: ContactService, private _toastrService: ToastrServices) { }

  ngOnInit() {
  }

  onAddButtonClick(contactForm: NgForm){
     var addedContact = new ContactDetails();
     addedContact.firstName = contactForm.controls['firstName'].value;
     addedContact.lastName = contactForm.controls['lastName'].value;
     addedContact.gender = contactForm.controls['gender'].value;
     addedContact.email = contactForm.controls['email'].value;
     addedContact.mobilePhone = contactForm.controls['mobilePhone'].value;
     addedContact.homePhone = contactForm.controls['homePhone'].value;
     addedContact.facebookId = contactForm.controls['facebookId'].value;
     addedContact.street = contactForm.controls['street'].value;
     addedContact.city = contactForm.controls['city'].value;
     addedContact.province = contactForm.controls['province'].value;
     addedContact.zipCode = contactForm.controls['zipcode'].value;

     this._contactService.AddContact(addedContact)
         .subscribe(
           result => {
             console.log('Contact Added.');
             console.log(addedContact);            
             this._toastrService.success('Contact Added Successfully.', '');
           },
           error => {
             console.log(error);
             this._toastrService.error('Contact Addition Failed.', 'Error');
           }); 
  }

}
