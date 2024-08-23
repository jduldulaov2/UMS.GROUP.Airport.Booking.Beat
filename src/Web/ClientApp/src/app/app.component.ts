import { Component } from '@angular/core';
import { SpinnerServiceService } from './Services/Shared/spinner-service.service';
import { AuthClient } from './web-api-client';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  public getLoggedInQueryDto: any;

  constructor(private loader: SpinnerServiceService, private authClient: AuthClient, private router: Router, private route: ActivatedRoute) {}

  title = 'app';

   IsAdminLoggedIn: any;

  ngOnInit(){

    var retrievedObject = localStorage.getItem('loggedindetail');

    if (typeof retrievedObject !== 'undefined' && retrievedObject !== null){
      // CONVERT STRING TO REGULAR JS OBJECT
      var parsedObject = JSON.parse(retrievedObject!);
      if(parsedObject.resultType == 1 && parsedObject.data?.isAdminAccount == false){
        this.IsAdminLoggedIn = false;
      }else if(parsedObject.resultType == 1 && parsedObject.data?.isAdminAccount == true){
        this.IsAdminLoggedIn = true;
      }else{
        this.IsAdminLoggedIn = false;
      }
    }else{
      this.IsAdminLoggedIn = false;
    }
  }
}
