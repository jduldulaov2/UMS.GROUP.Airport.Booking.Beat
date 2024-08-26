import { Component } from '@angular/core';
import { DraftCartItemsClient, GetAllDraftCartItemsQueryDtoByCode, UpdateDraftCartItemsCommand } from '../../../web-api-client';
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


}
