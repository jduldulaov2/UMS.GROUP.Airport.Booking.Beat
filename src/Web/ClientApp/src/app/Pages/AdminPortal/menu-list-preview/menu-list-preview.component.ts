import { Component } from '@angular/core';
import { FoodsClient, GetAllFoodQueryDto } from '../../../web-api-client';
declare var $: any;

@Component({
  selector: 'app-menu-list-preview',
  templateUrl: './menu-list-preview.component.html',
  styleUrls: ['./menu-list-preview.component.css']
})
export class MenuListPreviewComponent {
  public foodDto: GetAllFoodQueryDto[] = [];
  constructor(
    private foodsClient: FoodsClient
  ) {
  }

  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
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

  GetFoodItemsSelected(){
    var value = $(".select2bs4").val();
    if (value == -1){
      this.getFoodList();
    }else{
      this.getFoodListById(value);
    }
    
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

}
