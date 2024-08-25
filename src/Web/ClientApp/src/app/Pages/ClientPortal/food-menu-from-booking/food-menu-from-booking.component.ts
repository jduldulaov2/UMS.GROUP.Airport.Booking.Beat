import { Component } from '@angular/core';
import { FoodsClient, GetAllFoodQueryDto } from '../../../web-api-client';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-food-menu-from-booking',
  templateUrl: './food-menu-from-booking.component.html',
  styleUrls: ['./food-menu-from-booking.component.css']
})
export class FoodMenuFromBookingComponent {
  public foodDto: GetAllFoodQueryDto[] = [];
  constructor(
    private foodsClient: FoodsClient,
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

  GoBackToCart(id: any): void {
    //my-cart/booking/a7786e7e-91c6-4218-aeae-2b6ed12eee7e/detail
    // var draft_id = this.route.snapshot.paramMap.get('key');

    // alert(id);
    // alert(draft_id);

    this.router.navigate(['/my-cart/booking',this.route.snapshot.paramMap.get('key'),'detail']);
  }
  
}
