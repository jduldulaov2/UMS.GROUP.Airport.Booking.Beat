import { Component } from '@angular/core';
import { FoodsClient, DraftCartItemsClient, GetAllFoodQueryDto, GetAllDraftCartItemsQueryDtoByCode, CreateDraftCartItemsCommand } from '../../../web-api-client';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-food-menu-from-booking',
  templateUrl: './food-menu-from-booking.component.html',
  styleUrls: ['./food-menu-from-booking.component.css']
})
export class FoodMenuFromBookingComponent {
  public foodDto: GetAllFoodQueryDto[] = [];
  public draftDto: GetAllDraftCartItemsQueryDtoByCode[] = [];
  constructor(
    private foodsClient: FoodsClient,
    private draftClient: DraftCartItemsClient,
    private router: Router,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit(){
    this.getFoodList();
  }

  getFoodList(): void {
    this.foodsClient.getAllFood().subscribe({
      next: result => {
        this.foodDto = result;
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

  getFoodListById(id: any): void {
    this.foodsClient.getAllFoodByCategoryId(id).subscribe({
      next: result => {
        this.foodDto = result;
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

  GetFilter(){
    this.getFoodList();
  }

  GoBackToCart(id: any, price: any, quantity: any, total: any): void {
    //my-cart/booking/a7786e7e-91c6-4218-aeae-2b6ed12eee7e/detail
    var draft_id = this.route.snapshot.paramMap.get('key');

    const list = {
      "bookingReservationId": draft_id,
      "foodId": id,
      "currentPrice": price,
      "currrentQuantity": quantity,
      "currentTotal": total,
      "isActive": true
    };

    this.draftClient.createDraftCartItems(list as CreateDraftCartItemsCommand).subscribe(
      result => {
        if(result.resultType == 1){
          this.router.navigate(['/my-cart/booking',draft_id,'detail']);
        }else{
          alert(result.message);
        }
      },
      error => {
        const errors = JSON.parse(error.response).errors;
        alert(errors);
      }
    );
  }
  
}
