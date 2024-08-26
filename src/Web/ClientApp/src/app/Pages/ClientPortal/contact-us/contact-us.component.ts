import { Component } from '@angular/core';
declare var $: any;

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent {
  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
  }
}
