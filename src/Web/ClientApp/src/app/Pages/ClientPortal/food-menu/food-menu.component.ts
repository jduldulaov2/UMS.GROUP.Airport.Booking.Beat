import { Component } from '@angular/core';
import { FoodsClient, GetAllFoodQueryDto } from '../../../web-api-client';
declare var $: any;

@Component({
  selector: 'app-food-menu',
  templateUrl: './food-menu.component.html',
  styleUrls: ['./food-menu.component.css']
})
export class FoodMenuComponent {
  public foodDto: GetAllFoodQueryDto[] = [];
  constructor(
    private foodsClient: FoodsClient
  ) {
  }
  IsLoggedIn: any;

  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
    this.getFoodList();
    this.GetLogin();
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

  GetLogin(){
    // READ STRING FROM LOCAL STORAGE
var retrievedObject = localStorage.getItem('loggedindetail');

if (typeof retrievedObject !== 'undefined' && retrievedObject !== null){
  // CONVERT STRING TO REGULAR JS OBJECT
  var parsedObject = JSON.parse(retrievedObject!);
  
  this.IsLoggedIn = true;
}else{
  this.IsLoggedIn = false;
}
}

}
