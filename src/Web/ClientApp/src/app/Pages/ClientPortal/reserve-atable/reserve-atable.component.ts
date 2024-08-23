import { Component } from '@angular/core';
declare var $: any;

@Component({
  selector: 'app-reserve-atable',
  templateUrl: './reserve-atable.component.html',
  styleUrls: ['./reserve-atable.component.css']
})
export class ReserveATableComponent {

  ngOnInit(){
    this.GetInitialInfo();
  }

  GetInitialInfo(){
    // READ STRING FROM LOCAL STORAGE
  var retrievedObject = localStorage.getItem('loggedindetail');

  if (typeof retrievedObject !== 'undefined' && retrievedObject !== null){
    var parsedObject = JSON.parse(retrievedObject!);

    var fullName = parsedObject.data?.lastName + ', ' + parsedObject.data?.firstName + ' ' +  parsedObject.data?.middleName;
    var emailAddress = parsedObject.data?.emailAddress;
    var contactNumber = parsedObject.data?.contactNumber;
    var fullAddress = parsedObject.data?.street + ' ' + parsedObject.data?.city + ' ' + parsedObject.data?.region + ' ' + parsedObject.data?.zipCode;
    var user_id = parsedObject.data?.id;

    $("#fullname").val(fullName);
    $("#emailaddress").val(emailAddress);
    $("#phonenumber").val(contactNumber);

    }
  }

}
