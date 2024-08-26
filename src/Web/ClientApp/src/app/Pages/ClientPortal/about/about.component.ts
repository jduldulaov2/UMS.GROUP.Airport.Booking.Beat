import { Component } from '@angular/core';
declare var $: any;

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent {
  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
  }
}
