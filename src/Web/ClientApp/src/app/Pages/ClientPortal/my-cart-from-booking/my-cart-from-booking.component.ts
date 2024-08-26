import { Component } from '@angular/core';
import { DraftCartItemsClient, GetAllDraftCartItemsQueryDtoByCode, UpdateDraftCartItemsCommand } from '../../../web-api-client';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-my-cart-from-booking',
  templateUrl: './my-cart-from-booking.component.html',
  styleUrls: ['./my-cart-from-booking.component.css']
})
export class MyCartFromBookingComponent {
  public cartDto: GetAllDraftCartItemsQueryDtoByCode[] = [];
  hasOrder: any;
  getTotalAmount: any;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private cartClient: DraftCartItemsClient
  ) {
  }

  ngOnInit(){
    this.getCartList();
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

  updateCartItem(uniqueid: any, foodid: any, currentprice: any, currentquantity: any, currenttotal: any, isactive: any){
    var code_id = this.route.snapshot.paramMap.get('key');
    const list = {
      "uniqueId": uniqueid,
      "bookingReservationId": code_id,
      "foodId": foodid,
      "currentPrice": currentprice,
      "currrentQuantity": currentquantity,
      "currentTotal": currenttotal,
      "isActive": false
    };

    this.cartClient.updateDraftCartItems(list as UpdateDraftCartItemsCommand).subscribe(
      result => {
        if(result.resultType == 1){
          this.getCartList();
        }else{
          alert('Something went wrong. Check the validation error/s.');
          //this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
        }
      },
      error => {
        const errors = JSON.parse(error.response).errors;
        alert('Something went wrong. Check the validation error/s.');
      }
    );

  }

  RemoveQuantity(uniqueid: any, foodid: any, currentprice: any, currentquantity: any, currenttotal: any, isactive: any){
    var quantitynow = currentquantity - 1;
    var code_id = this.route.snapshot.paramMap.get('key');
    const list = {
      "uniqueId": uniqueid,
      "bookingReservationId": code_id,
      "foodId": foodid,
      "currentPrice": currentprice,
      "currrentQuantity": quantitynow,
      "currentTotal": currentprice * quantitynow,
      "isActive": true
    };

    this.cartClient.updateDraftCartItems(list as UpdateDraftCartItemsCommand).subscribe(
      result => {
        if(result.resultType == 1){
          this.getCartList();
        }else{
          alert('Something went wrong. Check the validation error/s.');
          //this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
        }
      },
      error => {
        const errors = JSON.parse(error.response).errors;
        alert('Something went wrong. Check the validation error/s.');
      }
    );
  }

  AddQuantity(uniqueid: any, foodid: any, currentprice: any, currentquantity: any, currenttotal: any, isactive: any){
    var quantitynow = currentquantity + 1;
    var code_id = this.route.snapshot.paramMap.get('key');
    const list = {
      "uniqueId": uniqueid,
      "bookingReservationId": code_id,
      "foodId": foodid,
      "currentPrice": currentprice,
      "currrentQuantity": quantitynow,
      "currentTotal": currentprice * quantitynow,
      "isActive": true
    };

    this.cartClient.updateDraftCartItems(list as UpdateDraftCartItemsCommand).subscribe(
      result => {
        if(result.resultType == 1){
          this.getCartList();
        }else{
          alert('Something went wrong. Check the validation error/s.');
          //this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
        }
      },
      error => {
        const errors = JSON.parse(error.response).errors;
        alert('Something went wrong. Check the validation error/s.');
      }
    );
  }

  GoToFoods(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
    this.router.navigate(['/food-menu/booking',this.route.snapshot.paramMap.get('key'),'detail']);
  }

  GoToCheckout(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
    this.router.navigate(['/checkout/booking',this.route.snapshot.paramMap.get('key'),'detail']);
  }
  
}
