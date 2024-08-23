import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthClient } from '../../../web-api-client';
declare var $: any;


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private authClient: AuthClient, private router: Router, private route: ActivatedRoute) {}

  LoginUser(username: any, password: any){
      this.authClient.login(username, password, false, false).subscribe({
        next: result => {
          if(result.resultType == 1 && result.data?.isAdminAccount == false){
            localStorage.setItem('loggedindetail', JSON.stringify(result));
            location.href = '/login/login-confirmation';
          }else if(result.resultType == 1 && result.data?.isAdminAccount == true){
            localStorage.setItem('loggedindetail', JSON.stringify(result));
            location.href = '/admin/my-dashboard';
          }else{
            alert("Username or password is incorrect.");
            //$("#alert").show();
          }
        },
        error: error => console.error(error)
      });
  }

}
