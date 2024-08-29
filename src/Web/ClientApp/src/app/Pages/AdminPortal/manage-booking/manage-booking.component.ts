import { Component } from '@angular/core';
import { RestaurantBookingsClient, GetAllRestaurantBookingQueryDto } from '../../../web-api-client';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-manage-booking',
  templateUrl: './manage-booking.component.html',
  styleUrls: ['./manage-booking.component.css']
})
export class ManageBookingComponent {

  public getAllRestaurantBookingQueryDto: GetAllRestaurantBookingQueryDto[] = [];
  constructor(
    private restaurantBookingsClient: RestaurantBookingsClient
  ) {
  }

  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
    this.getBookingList();
  }

  getBookingList(): void {
    this.restaurantBookingsClient.getAllRestaurantBooking().subscribe({
      next: result => {
        this.getAllRestaurantBookingQueryDto = result;
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

}
