import { Component } from '@angular/core';
declare var $: any;

@Component({
  selector: 'app-client-login-confirmation',
  templateUrl: './client-login-confirmation.component.html',
  styleUrls: ['./client-login-confirmation.component.css']
})
export class ClientLoginConfirmationComponent {
  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
    this.GetInitialInfo();
    
  }

  fullname: any;
  emailAddress: any;
  contactNumber: any;
  fullAddress: any;

  GetInitialInfo(){
    // READ STRING FROM LOCAL STORAGE
  var retrievedObject = localStorage.getItem('loggedindetail');

  if (typeof retrievedObject !== 'undefined' && retrievedObject !== null){
    var parsedObject = JSON.parse(retrievedObject!);
    this.fullname = parsedObject.data?.firstName + ' ' + parsedObject.data?.lastName;
    this.emailAddress = parsedObject.data?.emailAddress;
    this.contactNumber = parsedObject.data?.contactNumber;
    this.fullAddress = parsedObject.data?.street + ' ' + parsedObject.data?.city + ' ' + parsedObject.data?.region + ' ' + parsedObject.data?.zipCode;
    }
  }

}
