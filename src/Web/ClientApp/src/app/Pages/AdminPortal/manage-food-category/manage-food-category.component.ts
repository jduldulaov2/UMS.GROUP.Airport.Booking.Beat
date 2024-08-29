import { Component } from '@angular/core';
import { FoodCategoryClient, GetAllFoodCategoryQueryDto } from '../../../web-api-client';
declare var $: any;

@Component({
  selector: 'app-manage-food-category',
  templateUrl: './manage-food-category.component.html',
  styleUrls: ['./manage-food-category.component.css']
})
export class ManageFoodCategoryComponent {
  public getAllFoodCategoryQueryDto: GetAllFoodCategoryQueryDto[] = [];
  constructor(
    private foodCategoryClient: FoodCategoryClient
  ) {
  }

  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
    this.getCategoryList();
  }

  getCategoryList(): void {
    this.foodCategoryClient.getAllFoodCategory().subscribe({
      next: result => {
        this.getAllFoodCategoryQueryDto = result;
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

}
