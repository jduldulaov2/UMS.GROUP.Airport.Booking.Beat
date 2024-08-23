import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-my-cart-from-booking',
  templateUrl: './my-cart-from-booking.component.html',
  styleUrls: ['./my-cart-from-booking.component.css']
})
export class MyCartFromBookingComponent {
  constructor(
    private router: Router,
    private route: ActivatedRoute
  ) {
  }

  GoToFoods(){
    this.router.navigate(['/food-menu/booking',this.route.snapshot.paramMap.get('key'),'detail']);
  }
}
