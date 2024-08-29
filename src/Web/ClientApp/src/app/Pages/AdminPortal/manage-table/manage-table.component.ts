import { Component } from '@angular/core';
import { RestaurantTablesClient, GetAllRestaurantTableQueryDto } from '../../../web-api-client';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-manage-table',
  templateUrl: './manage-table.component.html',
  styleUrls: ['./manage-table.component.css']
})
export class ManageTableComponent {

  public getAllRestaurantTableQueryDto: GetAllRestaurantTableQueryDto[] = [];

  constructor(
    private restaurantTablesClient: RestaurantTablesClient,
    private router: Router,
    private route: ActivatedRoute,
  ) {
  }

  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
    this.getTableList();
  }

  getTableList(): void {
    this.restaurantTablesClient.getAllRestaurantTable().subscribe({
      next: result => {
        this.getAllRestaurantTableQueryDto = result;
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

}
