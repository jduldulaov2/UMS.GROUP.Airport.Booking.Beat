import { Component } from '@angular/core';
declare var $: any;

@Component({
  selector: 'app-client-login-confirmation',
  templateUrl: './client-login-confirmation.component.html',
  styleUrls: ['./client-login-confirmation.component.css']
})
export class ClientLoginConfirmationComponent {
  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
  }
}
