import { Component } from '@angular/core';
import { RestaurantTablesClient, GetAllRestaurantTableQueryDto, RestaurantBookingsClient, CreateRestaurantBookingCommand} from '../../../web-api-client';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-reserve-atable',
  templateUrl: './reserve-atable.component.html',
  styleUrls: ['./reserve-atable.component.css']
})
export class ReserveATableComponent {
  public getAllRestaurantTableQueryDto: GetAllRestaurantTableQueryDto[] = [];
  IsLoggedIn: any;
  user_code!: any;

  constructor(
    private router: Router,
    private restaurantBookingClient: RestaurantBookingsClient,
    private route: ActivatedRoute,
    private restaurantTablesClient: RestaurantTablesClient
    
  ) {
  }

  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
    this.GetInitialInfo();
    this.GetLogin();
    this.GetInitialInfo2();
    this.getTableList();
  }
  

  fullName: any;
  emailAddress: any;
  contactNumber: any;
  fullAddress: any;

  GetInitialInfo2(){
    // READ STRING FROM LOCAL STORAGE
  var retrievedObject = localStorage.getItem('loggedindetail');

  if (typeof retrievedObject !== 'undefined' && retrievedObject !== null){
    var parsedObject = JSON.parse(retrievedObject!);
    this.fullName = parsedObject.data?.firstName + ' ' + parsedObject.data?.lastName;
    this.emailAddress = parsedObject.data?.emailAddress;
    this.contactNumber = parsedObject.data?.contactNumber;
    this.fullAddress = parsedObject.data?.street + ' ' + parsedObject.data?.city + ' ' + parsedObject.data?.region + ' ' + parsedObject.data?.zipCode;
    }
  }

  GetInitialInfo(){
    // READ STRING FROM LOCAL STORAGE
  var retrievedObject = localStorage.getItem('loggedindetail');

  if (typeof retrievedObject !== 'undefined' && retrievedObject !== null){
    var parsedObject = JSON.parse(retrievedObject!);

    var fullName = parsedObject.data?.firstName + ' ' + parsedObject.data?.lastName;
    var emailAddress = parsedObject.data?.emailAddress;
    var contactNumber = parsedObject.data?.contactNumber;
    var fullAddress = parsedObject.data?.street + ' ' + parsedObject.data?.city + ' ' + parsedObject.data?.region + ' ' + parsedObject.data?.zipCode;
    var user_id = parsedObject.data?.id;
    this.user_code = user_id;

    }
  }

  GetLogin(){
      // READ STRING FROM LOCAL STORAGE
  var retrievedObject = localStorage.getItem('loggedindetail');

  if (typeof retrievedObject !== 'undefined' && retrievedObject !== null){
    this.IsLoggedIn = true;
  }else{
    this.IsLoggedIn = false;
  }
  }

  getTableList(): void {
    this.restaurantTablesClient.getAllRestaurantTable().subscribe({
      next: result => {
        this.getAllRestaurantTableQueryDto = result;
        console.log(result);
        setTimeout(() => {
          $('.select2').select2();
        }, 1000);
      },
      error: error => console.error(error)
    });
  }

  GetTable(){
    $('#entertable').val($('#TableList').val());
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
            let booking_id:string = result.data?.id!; 
            localStorage.setItem('bookingnumber', booking_id);
            this.router.navigate(['/my-cart/booking/',result.data?.id,'detail']);
          }else{
            this.Notification(result.message, "error");
            //this.loader.DisplayErrorMessage(result.message);
            //this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
          }
        },
        error => {
          const errors = JSON.parse(error.response).errors;
          alert(errors);
          this.Notification(errors, "error");
        }
      );
    }else{
      this.Notification("Some fields are required.", "error");
    }


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
