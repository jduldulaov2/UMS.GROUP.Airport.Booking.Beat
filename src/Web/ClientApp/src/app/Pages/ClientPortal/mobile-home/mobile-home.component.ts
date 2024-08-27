import { Component } from '@angular/core';
import { AuthClient } from '../../../web-api-client';
declare var $: any;

@Component({
  selector: 'app-mobile-home',
  templateUrl: './mobile-home.component.html',
  styleUrls: ['./mobile-home.component.css']
})
export class MobileHomeComponent {

  constructor(private authClient: AuthClient) {}
  
  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
    this.GetLogin();
  }

  IsLoggedIn: any;

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
