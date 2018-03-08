import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { ContactService } from './services/contact.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  names: string[]
  
  constructor(private _contactService: ContactService, private _router: Router) { }

  ngOnInit() {
    this.getAllContactNames();
  }

  onItemAdded(searchTag){   
    this._router.navigate(['searchContact/', searchTag.value]); 
    //console.log(searchTag.value);
  }

  onItemRemoved(){
    this._router.navigate(['']); 
  }

  getAllContactNames(): void {
    this._contactService.getAllContactNames()
      .subscribe(names => {
        this.names = names;
        //console.log(this.names);
      },
      error => {
        console.log(error);
    });        
  }
  
}
