import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthClient } from '../../web-api-client';

@Component({
  selector: 'app-header-client',
  templateUrl: './header-client.component.html',
  styleUrls: ['./header-client.component.css']
})
export class HeaderClientComponent {
  isExpanded = false;
  IsLoggedIn: any;

  local_url!: any;

  constructor(private authClient: AuthClient) {}

  ngOnInit(){
    this.GetLogin();
  }

  GetLogin(){
    // READ STRING FROM LOCAL STORAGE
  var retrievedObject = localStorage.getItem('loggedindetail');

  if (typeof retrievedObject !== 'undefined' && retrievedObject !== null){
    // CONVERT STRING TO REGULAR JS OBJECT
    var parsedObject = JSON.parse(retrievedObject!);
    
    this.IsLoggedIn = true;
  }else{
    this.IsLoggedIn = false;
  }
  }

  SignOut(){
    this.authClient.geLoggedIn().subscribe({
      next: result => {
        if(result.resultType == 1){
          var loggedInId = result.data?.loggedInId;
          this.ProceedSignOut(loggedInId);
        }else{
          localStorage.clear();
          location.href = '/login';
        }
      },
      error: error => console.error(error)
    });
  }

  ProceedSignOut(id: any){
    this.authClient.logOut(id).subscribe({
      next: result => {
        if(result.resultType == 1){
          localStorage.clear();
          location.href = '/login';
        }
      },
      error: error => console.error(error)
    });
  }

}
