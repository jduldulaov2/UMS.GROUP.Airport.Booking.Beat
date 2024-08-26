import { Component } from '@angular/core';
declare var $: any;

@Component({
  selector: 'app-client-registration-confirmation',
  templateUrl: './client-registration-confirmation.component.html',
  styleUrls: ['./client-registration-confirmation.component.css']
})
export class ClientRegistrationConfirmationComponent {
  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
  }
}
