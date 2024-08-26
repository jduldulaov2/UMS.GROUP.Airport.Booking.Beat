import { Component } from '@angular/core';
import { RestaurantBookingsClient, CreateRestaurantBookingCommand} from '../../../web-api-client';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-reserve-atable',
  templateUrl: './reserve-atable.component.html',
  styleUrls: ['./reserve-atable.component.css']
})
export class ReserveATableComponent {

  constructor(
    private router: Router,
    private restaurantBookingClient: RestaurantBookingsClient,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit(){
    this.GetInitialInfo();
  }
  

  user_code!: any;

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
    this.user_code = user_id;

    $("#fullname").val(fullName);
    $("#emailaddress").val(emailAddress);
    $("#phonenumber").val(contactNumber);

    }
  }

  ReserveATable(fullname: any, 
    emailaddress: any , 
    phonenumber: any,
    bookingdate: any, 
    bookingtime: any, 
    numberofpeople: any,
    message: any){
      
    var errorMessage = '';
 
    var array = new Uint32Array(1);
    window.crypto.getRandomValues(array);

    const list = {
      "bookingReferrenceNumber": "REF-" + array,
      "bookingFromDate": bookingdate,
      "bookingToDate": bookingdate,
      "bookingSource": "Web Application",
      "bookingEstimatedArrivalTime": bookingtime,
      "bookingEstimatedDepartureTime": bookingtime,
      "bookingStatusID": 0,
      "bookingPaymentStatusID": 0,
      "bookingChargesAmount": 0,
      "bookingExtrasAmount": 0,
      "bookingPromoAmount": 0,
      "bookingTaxAmount": 0,
      "bookingPaymentSurchargeAmount": 0,
      "bookingTotalAmount": 0,
      "bookingPaidAmount": 0,
      "bookingOutstandingBalanceAmount": 0,
      "bookingNotes": message,
      "paymentMethod": "IBAN",
      "restaurantID": 1,
      "guestID": this.user_code,
      "orderID": 0,
      "guestName": fullname,
      "restaurantName": "Thoracker",
      "isActive": true,
      "numberOfPax": numberofpeople
    };

    $("#firstname").removeClass("haserror");
    $("#lastname").removeClass("haserror");
    $("#contactnumber").removeClass("haserror");
    $("#birthdate").removeClass("haserror");
    $("#street1").removeClass("haserror");
    $("#city").removeClass("haserror");
    $("#zip").removeClass("haserror");
    $("#emailaddress").removeClass("haserror");
    $("#password").removeClass("haserror");
    $("#confirmpassword").removeClass("haserror");

    if(bookingdate == ''){
      errorMessage += "bookingdate is required<br>";
      $("#bookingdate").addClass("haserror");
    }

    if(bookingtime == ''){
      errorMessage += "bookingtime is required<br>";
      $("#bookingtime").addClass("haserror");
    }

    if(numberofpeople == ''){
      errorMessage += "numberofpeople number is required<br>";
      $("#numberofpeople").addClass("haserror");
    }

  
    if(errorMessage == ''){
      this.restaurantBookingClient.createRestaurantBooking(list as CreateRestaurantBookingCommand).subscribe(
        result => {
          if(result.resultType == 1){
            //alert(result.data?.id);
            //this.loader.ShowToast("New Airport has been successfully added.", "success");
            //this.router.navigate(['login/registration-confirmation']); my-cart/booking/19283098230840982908908r/detail
            this.router.navigate(['/my-cart/booking/',result.data?.id,'detail']);
          }else{
            alert(result.message);
            //this.loader.DisplayErrorMessage(result.message);
            //this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
          }
        },
        error => {
          const errors = JSON.parse(error.response).errors;
          alert(errors);
          //this.loader.DisplayErrorMessage(errors);
          //this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
        }
      );
    }else{
      alert("Some fields are required.");
      //this.loader.DisplayErrorMessage(errorMessage);
      //this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
    }


  }

}
