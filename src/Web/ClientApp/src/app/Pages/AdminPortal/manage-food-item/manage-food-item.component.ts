import { Component } from '@angular/core';
import { FoodsClient, GetAllFoodQueryDto } from '../../../web-api-client';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;


@Component({
  selector: 'app-manage-food-item',
  templateUrl: './manage-food-item.component.html',
  styleUrls: ['./manage-food-item.component.css']
})
export class ManageFoodItemComponent {
  public getAllFoodQueryDto: GetAllFoodQueryDto[] = [];

  constructor(
    private foodsClient: FoodsClient,
    private router: Router,
    private route: ActivatedRoute,
  ) {
  }

  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
    this.getFoodList();
  }

  getFoodList(): void {
    this.foodsClient.getAllFood().subscribe({
      next: result => {
        this.getAllFoodQueryDto = result;
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

}
