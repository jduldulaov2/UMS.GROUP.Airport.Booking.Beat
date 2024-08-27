import { Component } from '@angular/core';
import { AuthClient } from '../../../web-api-client';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;


@Component({
  selector: 'app-mobile-home',
  templateUrl: './mobile-home.component.html',
  styleUrls: ['./mobile-home.component.css']
})
export class MobileHomeComponent {

  constructor(private authClient: AuthClient, private router: Router,
    private route: ActivatedRoute) {}
  
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

  OpenCheckout(){
    var bookingnumber = localStorage.getItem("bookingnumber");
    if (typeof bookingnumber !== 'undefined' && bookingnumber !== null){
      this.router.navigate(['/checkout/booking',bookingnumber,'detail']);
      this.router
    }else{
      this.Notification("Checkout page is still empty. Create a booking/order first.","error");
    }

  }

  OpenCart(){
    var bookingnumber = localStorage.getItem("bookingnumber");
    if (typeof bookingnumber !== 'undefined' && bookingnumber !== null){
      this.router.navigate(['/my-cart/booking',bookingnumber,'detail']);
    }else{
      this.Notification("Cart page is still empty. Create a booking/order first.","error");
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

  Notification(message: any, type: any){
    if(type == "error"){
      $(".error-message").addClass("display-message");
      $(".success-message").removeClass("display-message");
      $(".error-message").html(message);
    }else{
      $(".error-message").removeClass("display-message");
      $(".success-message").addClass("display-message");
      $(".success-message").html(message);
    }

    setTimeout(() => {
      $(".success-message").removeClass("display-message");
      $(".error-message").removeClass("display-message");
    }, 2000);

  }

}
