import { Component } from '@angular/core';
import { RestaurantUserLogsClient, GetAllRestaurantUserLogQueryDto } from '../../../web-api-client';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  public getAllRestaurantUserLogQueryDto: GetAllRestaurantUserLogQueryDto[] = [];
  constructor(
    private restaurantUserLogsClient: RestaurantUserLogsClient
  ) {
  }

  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
    this.getActivityList();
  }

  getActivityList(): void {
    this.restaurantUserLogsClient.getAllRestaurantUserLog().subscribe({
      next: result => {
        this.getAllRestaurantUserLogQueryDto = result;
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

}
