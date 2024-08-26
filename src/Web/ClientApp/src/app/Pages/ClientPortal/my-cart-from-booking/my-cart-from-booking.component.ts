import { Component } from '@angular/core';
import { DraftCartItemsClient, GetAllDraftCartItemsQueryDtoByCode } from '../../../web-api-client';
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
    var code_id = this.route.snapshot.paramMap.get('key');
    this.cartClient.getAllDraftCartItemsByCode(code_id).subscribe({
      next: result => {
        this.cartDto = result;
        console.log(result);
        if(result.length > 0){
          this.hasOrder = true;
        }else{
          this.hasOrder = false;
        }
      },
      error: error => console.error(error)
    });
  }

  GoToFoods(){
    this.router.navigate(['/food-menu/booking',this.route.snapshot.paramMap.get('key'),'detail']);
  }

  GoToCheckout(){
    this.router.navigate(['/checkout']);
  }
  
}
