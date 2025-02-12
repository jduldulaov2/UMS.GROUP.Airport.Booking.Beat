import { Component } from '@angular/core';
import { RestaurantUserLogsClient, CreateRestaurantUserLogCommand, AuthClient, SendEmailDto, DraftCartItemsClient, GetAllDraftCartItemsQueryDtoByCode, UpdateDraftCartItemsCommand, RestaurantBookingsClient, GetAllRestaurantBookingByIdQueryDto, UpdateRestaurantBookingCommand } from '../../../web-api-client';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-manage-booking-detail',
  templateUrl: './manage-booking-detail.component.html',
  styleUrls: ['./manage-booking-detail.component.css']
})
export class ManageBookingDetailComponent {
  public cartDto: GetAllDraftCartItemsQueryDtoByCode[] = [];
  hasOrder: any;
  getTotalAmount: any;
  user_code!: any;

  fullname: any;
  emailAddress: any;
  contactNumber: any;
  fullAddress: any;

  b_uniqueId: any;
  b_bookingReferrenceNumber: any;
  b_bookingFromDate: any;
  b_bookingToDate: any;
  b_bookingSource: any;
  b_bookingEstimatedArrivalTime: any;
  b_bookingEstimatedDepartureTime: any;
  b_bookingStatusID: any;
  b_bookingPaymentStatusID: any;
  b_bookingChargesAmount: any;
  b_bookingExtrasAmount: any;
  b_bookingPromoAmount: any;
  b_bookingTaxAmount: any;
  b_bookingPaymentSurchargeAmount: any;
  b_bookingTotalAmount: any;
  b_bookingPaidAmount: any;
  b_bookingOutstandingBalanceAmount: any;
  b_bookingNotes: any;
  b_paymentMethod: any;
  b_restaurantID: any;
  b_guestID: any;
  b_orderID: any;
  b_guestName: any;
  b_restaurantName: any;
  b_isActive: any;
  b_numberOfPax: any;
  b_selectedTables:any;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private cartClient: DraftCartItemsClient,
    private bookingClient: RestaurantBookingsClient,
    private authClient: AuthClient,
    private restaurantUserLogsClient: RestaurantUserLogsClient
  ) {
  }

  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
    this.getCartList();
    var code_id = this.route.snapshot.paramMap.get('key');
    this.GetInitialInfo();
    this.getBookingById(code_id);
  }

  GoToCart(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
    this.router.navigate(['/admin/manage-booking']);
  }

  getBookingById(id: any): void {
    this.bookingClient.getAllRestaurantBookingById(id).subscribe({
      next: result => {
        this.b_uniqueId = result.data?.uniqueId;
        this.b_bookingReferrenceNumber = result.data?.bookingReferrenceNumber;
        this.b_bookingFromDate = result.data?.bookingFromDate;
        this.b_bookingToDate = result.data?.bookingToDate;;
        this.b_bookingSource = result.data?.bookingSource;;
        this.b_bookingEstimatedArrivalTime = result.data?.bookingEstimatedArrivalTime;
        this.b_bookingEstimatedDepartureTime = result.data?.bookingEstimatedDepartureTime ;
        this.b_bookingStatusID = result.data?.bookingStatusID;
        this.b_bookingPaymentStatusID = result.data?.bookingPaymentStatusID;
        this.b_bookingChargesAmount = result.data?.bookingChargesAmount;
        this.b_bookingExtrasAmount = result.data?.bookingExtrasAmount;
        this.b_bookingPromoAmount = result.data?.bookingPromoAmount;
        this.b_bookingTaxAmount = result.data?.bookingTaxAmount;
        this.b_bookingPaymentSurchargeAmount = result.data?.bookingPaymentSurchargeAmount;
        this.b_bookingTotalAmount = result.data?.bookingTotalAmount ;
        this.b_bookingPaidAmount = result.data?.bookingPaidAmount;
        this.b_bookingOutstandingBalanceAmount = result.data?.bookingOutstandingBalanceAmount;
        this.b_bookingNotes = result.data?.bookingNotes;
        this.b_paymentMethod = result.data?.paymentMethod;
        this.b_restaurantID = result.data?.restaurantID;
        this.b_guestID = result.data?.guestID;
        this.b_orderID = result.data?.orderID;
        this.b_guestName = result.data?.guestName ;
        this.b_restaurantName = result.data?.restaurantName;
        this.b_isActive = result.data?.isActive ;
        this.b_numberOfPax = result.data?.numberOfPax;
        this.b_selectedTables = result.data?.selectedTables;
      },
      error: error => console.error(error)
    });
  }

  SendBookingForApproval(){
    
    var code_id = this.route.snapshot.paramMap.get('key');
    const list = {
      "uniqueId": this.b_uniqueId,
      "bookingReferrenceNumber": this.b_bookingReferrenceNumber,
      "bookingFromDate": this.b_bookingFromDate,
      "bookingToDate": this.b_bookingToDate,
      "bookingSource": this.b_bookingSource,
      "bookingEstimatedArrivalTime": this.b_bookingEstimatedArrivalTime,
      "bookingEstimatedDepartureTime": this.b_bookingEstimatedDepartureTime,
      "bookingStatusID": 3, //for approval
      "bookingPaymentStatusID": this.b_bookingPaymentStatusID,
      "bookingChargesAmount": this.b_bookingChargesAmount,
      "bookingExtrasAmount": this.b_bookingExtrasAmount,
      "bookingPromoAmount": this.b_bookingPromoAmount,
      "bookingTaxAmount": this.b_bookingTaxAmount,
      "bookingPaymentSurchargeAmount": this.b_bookingPaymentSurchargeAmount,
      "bookingTotalAmount": this.b_bookingTotalAmount,
      "bookingPaidAmount": this.b_bookingPaidAmount,
      "bookingOutstandingBalanceAmount": this.b_bookingOutstandingBalanceAmount,
      "bookingNotes": this.b_bookingNotes,
      "paymentMethod": this.b_paymentMethod,
      "restaurantID": this.b_restaurantID,
      "guestID": this.b_guestID,
      "orderID": this.b_orderID,
      "isActive": this.b_isActive,
      "guestName": this.b_guestName,
      "restaurantName": this.b_restaurantName,
      "numberOfPax": this.b_numberOfPax,
      "selectedTables": this.b_selectedTables
    };

    this.bookingClient.updateRestaurantBooking(list as UpdateRestaurantBookingCommand).subscribe(
      result => {
        if(result.resultType == 1){

          const list = {
            "bookingNumber": this.b_bookingReferrenceNumber ,
            "fullName": this.fullname,
            "bookingLogs": "has submitted a booking for Date: "+this.b_bookingFromDate,
            "bookingStatusId": "3",
            "isActive": true
          };
      
          this.restaurantUserLogsClient.createRestaurantUserLog(list as CreateRestaurantUserLogCommand).subscribe(
            result => {
              
            },
            error => {
              const errors = JSON.parse(error.response).errors;
              this.Notification(errors, "error");
            }
          );

          this.Notification("Booking as been submitted. Please wait for the response approval from the restaurant.", "success");
          this.authClient.sendEmail('thorackerrestaurant@gmail.com', 
            this.emailAddress, 
            'liepweijlwnyucjq',
            'Hi <b>'+ this.fullname + '</b><br><br>' 
            +'Thank you for sending your booking with referrence #: <b>' + this.b_bookingReferrenceNumber 
            +'</b>.<br><br>We will review the booking details and get back to you ASAP. <br><br>'+
            '-------Summary------<br>' + 
            '<b>Selected Tables: </b>' + this.b_selectedTables + '<br>'+ 
            '<b>Date of Arrival: </b>' + this.b_bookingFromDate + '<br>'+ 
            '<b>Time of Arrival: </b>' + this.b_bookingEstimatedArrivalTime + '<br>'+ 
            '<b>Booking Status: </b> <span style="color: red;">For Approval</span> <br>'+ 
            '<br>'+ 
            +'<br>Best Regards!<br><br><br> Thoracker Admin',
            'smtp.gmail.com',
            'Reservation (For Approval): ' + this.b_bookingReferrenceNumber, 
            587
            ).subscribe(
            result => {
              
            },
            error => {
              const errors = JSON.parse(error.response).errors;
              this.Notification("Something went wrong. Check the validation error/s.", "error");
            }
          );

          this.authClient.sendEmail('thorackerrestaurant@gmail.com', 
            'thorackerrestaurant@gmail.com', 
            'liepweijlwnyucjq',
            'Hi <b> System Administrator</b><br><br>' 
            +'There is a new booking with referrence #: <b>' + this.b_bookingReferrenceNumber 
            +'</b>.<br><br>Please review. <br><br>'+
            '-------Booking Summary------<br>' + 
            '<b>Name of Guest: </b>' + this.fullname + '<br>'+ 
            '<b>Address: </b>' + this.fullAddress + '<br>'+ 
            '<b>Contact Number: </b>' + this.contactNumber + '<br>'+ 
            '<b>Selected Tables: </b>' + this.b_selectedTables + '<br>'+ 
            '<b>Date of Arrival: </b>' + this.b_bookingFromDate + '<br>'+ 
            '<b>Time of Arrival: </b>' + this.b_bookingEstimatedArrivalTime + '<br>'+ 
            '<b>Booking Status: </b> <span style="color: red;">For Approval</span> <br>'+ 
            '<br>'+ 
            +'<br>Best Regards!<br><br><br> Thoracker Admin',
            'smtp.gmail.com',
            'Reservation (For Approval): ' + this.b_bookingReferrenceNumber, 
            587
            ).subscribe(
            result => {
              
            },
            error => {
              const errors = JSON.parse(error.response).errors;
              this.Notification("Something went wrong. Check the validation error/s.", "error");
            }
          );

          setTimeout(() => {
            this.getBookingById(code_id);
          }, 2000);
          
        }else{
          this.Notification("Something went wrong. Check the validation error/s.", "error");
          //this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
        }
      },
      error => {
        const errors = JSON.parse(error.response).errors;
        this.Notification("Something went wrong. Check the validation error/s.", "error");
      }
    );
  }

  RejectBooking(){
    
    var code_id = this.route.snapshot.paramMap.get('key');
    const list = {
      "uniqueId": this.b_uniqueId,
      "bookingReferrenceNumber": this.b_bookingReferrenceNumber,
      "bookingFromDate": this.b_bookingFromDate,
      "bookingToDate": this.b_bookingToDate,
      "bookingSource": this.b_bookingSource,
      "bookingEstimatedArrivalTime": this.b_bookingEstimatedArrivalTime,
      "bookingEstimatedDepartureTime": this.b_bookingEstimatedDepartureTime,
      "bookingStatusID": 2, //Reject
      "bookingPaymentStatusID": this.b_bookingPaymentStatusID,
      "bookingChargesAmount": this.b_bookingChargesAmount,
      "bookingExtrasAmount": this.b_bookingExtrasAmount,
      "bookingPromoAmount": this.b_bookingPromoAmount,
      "bookingTaxAmount": this.b_bookingTaxAmount,
      "bookingPaymentSurchargeAmount": this.b_bookingPaymentSurchargeAmount,
      "bookingTotalAmount": this.b_bookingTotalAmount,
      "bookingPaidAmount": this.b_bookingPaidAmount,
      "bookingOutstandingBalanceAmount": this.b_bookingOutstandingBalanceAmount,
      "bookingNotes": this.b_bookingNotes,
      "paymentMethod": this.b_paymentMethod,
      "restaurantID": this.b_restaurantID,
      "guestID": this.b_guestID,
      "orderID": this.b_orderID,
      "isActive": this.b_isActive,
      "guestName": this.b_guestName,
      "restaurantName": this.b_restaurantName,
      "numberOfPax": this.b_numberOfPax,
      "selectedTables": this.b_selectedTables
    };

    this.bookingClient.updateRestaurantBooking(list as UpdateRestaurantBookingCommand).subscribe(
      result => {
        if(result.resultType == 1){
          this.Notification("Booking has been Rejected.", "error");
          // this.authClient.sendEmail('thorackerrestaurant@gmail.com', 
          //   this.emailAddress, 
          //   'liepweijlwnyucjq',
          //   'Hi <b>'+ this.fullname + '</b><br><br>' 
          //   +'Thank you for sending your booking with referrence #: <b>' + this.b_bookingReferrenceNumber 
          //   +'</b>.<br><br>We will review the booking details and get back to you ASAP. <br><br>'+
          //   '-------Summary------<br>' + 
          //   '<b>Selected Tables: </b>' + this.b_selectedTables + '<br>'+ 
          //   '<b>Date of Arrival: </b>' + this.b_bookingFromDate + '<br>'+ 
          //   '<b>Time of Arrival: </b>' + this.b_bookingEstimatedArrivalTime + '<br>'+ 
          //   '<b>Booking Status: </b> <span style="color: red;">For Approval</span> <br>'+ 
          //   '<br>'+ 
          //   +'<br>Best Regards!<br><br><br> Thoracker Admin',
          //   'smtp.gmail.com',
          //   'Reservation (For Approval): ' + this.b_bookingReferrenceNumber, 
          //   587
          //   ).subscribe(
          //   result => {
              
          //   },
          //   error => {
          //     const errors = JSON.parse(error.response).errors;
          //     this.Notification("Something went wrong. Check the validation error/s.", "error");
          //   }
          // );

          this.authClient.sendEmail('thorackerrestaurant@gmail.com', 
            'thorackerrestaurant@gmail.com', 
            'liepweijlwnyucjq',
            'Hi <b> System Administrator</b><br><br>' 
            +'Booking with referrence #: <b>' + this.b_bookingReferrenceNumber 
            +'</b> has been rejected.<br><br>'+
            +'<br>Best Regards!<br><br><br> Thoracker Admin',
            'smtp.gmail.com',
            'Reservation Approved: ' + this.b_bookingReferrenceNumber, 
            587
            ).subscribe(
            result => {
              
            },
            error => {
              const errors = JSON.parse(error.response).errors;
              this.Notification("Something went wrong. Check the validation error/s.", "error");
            }
          );

          setTimeout(() => {
            this.getBookingById(code_id);
          }, 2000);
          
        }else{
          this.Notification("Something went wrong. Check the validation error/s.", "error");
          //this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
        }
      },
      error => {
        const errors = JSON.parse(error.response).errors;
        this.Notification("Something went wrong. Check the validation error/s.", "error");
      }
    );
  }

  ApproveBooking(){
    
    var code_id = this.route.snapshot.paramMap.get('key');
    const list = {
      "uniqueId": this.b_uniqueId,
      "bookingReferrenceNumber": this.b_bookingReferrenceNumber,
      "bookingFromDate": this.b_bookingFromDate,
      "bookingToDate": this.b_bookingToDate,
      "bookingSource": this.b_bookingSource,
      "bookingEstimatedArrivalTime": this.b_bookingEstimatedArrivalTime,
      "bookingEstimatedDepartureTime": this.b_bookingEstimatedDepartureTime,
      "bookingStatusID": 1, //Approve
      "bookingPaymentStatusID": this.b_bookingPaymentStatusID,
      "bookingChargesAmount": this.b_bookingChargesAmount,
      "bookingExtrasAmount": this.b_bookingExtrasAmount,
      "bookingPromoAmount": this.b_bookingPromoAmount,
      "bookingTaxAmount": this.b_bookingTaxAmount,
      "bookingPaymentSurchargeAmount": this.b_bookingPaymentSurchargeAmount,
      "bookingTotalAmount": this.b_bookingTotalAmount,
      "bookingPaidAmount": this.b_bookingPaidAmount,
      "bookingOutstandingBalanceAmount": this.b_bookingOutstandingBalanceAmount,
      "bookingNotes": this.b_bookingNotes,
      "paymentMethod": this.b_paymentMethod,
      "restaurantID": this.b_restaurantID,
      "guestID": this.b_guestID,
      "orderID": this.b_orderID,
      "isActive": this.b_isActive,
      "guestName": this.b_guestName,
      "restaurantName": this.b_restaurantName,
      "numberOfPax": this.b_numberOfPax,
      "selectedTables": this.b_selectedTables
    };

    this.bookingClient.updateRestaurantBooking(list as UpdateRestaurantBookingCommand).subscribe(
      result => {
        if(result.resultType == 1){
          this.Notification("Booking has been Approved.", "success");
          // this.authClient.sendEmail('thorackerrestaurant@gmail.com', 
          //   this.emailAddress, 
          //   'liepweijlwnyucjq',
          //   'Hi <b>'+ this.fullname + '</b><br><br>' 
          //   +'Thank you for sending your booking with referrence #: <b>' + this.b_bookingReferrenceNumber 
          //   +'</b>.<br><br>We will review the booking details and get back to you ASAP. <br><br>'+
          //   '-------Summary------<br>' + 
          //   '<b>Selected Tables: </b>' + this.b_selectedTables + '<br>'+ 
          //   '<b>Date of Arrival: </b>' + this.b_bookingFromDate + '<br>'+ 
          //   '<b>Time of Arrival: </b>' + this.b_bookingEstimatedArrivalTime + '<br>'+ 
          //   '<b>Booking Status: </b> <span style="color: red;">For Approval</span> <br>'+ 
          //   '<br>'+ 
          //   +'<br>Best Regards!<br><br><br> Thoracker Admin',
          //   'smtp.gmail.com',
          //   'Reservation (For Approval): ' + this.b_bookingReferrenceNumber, 
          //   587
          //   ).subscribe(
          //   result => {
              
          //   },
          //   error => {
          //     const errors = JSON.parse(error.response).errors;
          //     this.Notification("Something went wrong. Check the validation error/s.", "error");
          //   }
          // );

          this.authClient.sendEmail('thorackerrestaurant@gmail.com', 
            'thorackerrestaurant@gmail.com', 
            'liepweijlwnyucjq',
            'Hi <b> System Administrator</b><br><br>' 
            +'Booking with referrence #: <b>' + this.b_bookingReferrenceNumber 
            +'</b> has been approved.<br><br>Please review. <br><br>'+
            +'<br>Best Regards!<br><br><br> Thoracker Admin',
            'smtp.gmail.com',
            'Reservation Approved: ' + this.b_bookingReferrenceNumber, 
            587
            ).subscribe(
            result => {
              
            },
            error => {
              const errors = JSON.parse(error.response).errors;
              this.Notification("Something went wrong. Check the validation error/s.", "error");
            }
          );

          setTimeout(() => {
            this.getBookingById(code_id);
          }, 2000);
          
        }else{
          this.Notification("Something went wrong. Check the validation error/s.", "error");
          //this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
        }
      },
      error => {
        const errors = JSON.parse(error.response).errors;
        this.Notification("Something went wrong. Check the validation error/s.", "error");
      }
    );
  }

  

  GetInitialInfo(){
    // READ STRING FROM LOCAL STORAGE
  var retrievedObject = localStorage.getItem('loggedindetail');

  if (typeof retrievedObject !== 'undefined' && retrievedObject !== null){
    var parsedObject = JSON.parse(retrievedObject!);

    this.fullname = parsedObject.data?.firstName + ' ' + parsedObject.data?.lastName;
    this.emailAddress = parsedObject.data?.emailAddress;
    this.contactNumber = parsedObject.data?.contactNumber;
    this.fullAddress = parsedObject.data?.street + ' ' + parsedObject.data?.city + ' ' + parsedObject.data?.region + ' ' + parsedObject.data?.zipCode;
    var user_id = parsedObject.data?.id;
    this.user_code = user_id;

    }
  }


  getCartList(): void {
    this.getTotalAmount = 0;
    var code_id = this.route.snapshot.paramMap.get('key');
    this.cartClient.getAllDraftCartItemsByCode(code_id).subscribe({
      next: result => {
        this.cartDto = result;
        console.log(result);
        if(result.length > 0){
          this.hasOrder = true;
          for(var i = 0; i < result.length; i++) {
              var obj = result[i];
              this.getTotalAmount = this.getTotalAmount + obj.currentTotal;
          }
        }else{
          this.hasOrder = false;
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

