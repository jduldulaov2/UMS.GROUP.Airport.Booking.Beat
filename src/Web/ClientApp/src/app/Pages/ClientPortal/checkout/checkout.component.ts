import { Component } from '@angular/core';
declare var $: any;

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent {
  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
  }
}
