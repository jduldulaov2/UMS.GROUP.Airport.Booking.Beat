import { Component } from '@angular/core';
declare var $: any;

@Component({
  selector: 'app-mobile-home',
  templateUrl: './mobile-home.component.html',
  styleUrls: ['./mobile-home.component.css']
})
export class MobileHomeComponent {
  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
  }

}
