import { Component } from '@angular/core';
import { DraftCartItemsClient, GetAllDraftCartItemsQueryDtoByCode, UpdateDraftCartItemsCommand, RestaurantBookingsClient, GetAllRestaurantBookingByIdQueryDto } from '../../../web-api-client';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;


@Component({
  selector: 'app-checkout-from-booking',
  templateUrl: './checkout-from-booking.component.html',
  styleUrls: ['./checkout-from-booking.component.css']
})
export class CheckoutFromBookingComponent {
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

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private cartClient: DraftCartItemsClient,
    private bookingClient: RestaurantBookingsClient
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
    this.router.navigate(['/my-cart/booking',this.route.snapshot.paramMap.get('key'),'detail']);
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
      },
      error: error => console.error(error)
    });
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


}
