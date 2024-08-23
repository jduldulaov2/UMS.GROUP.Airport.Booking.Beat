import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  LoginUser(username: any, 
    password: any){
      
      alert(username);
      alert(password);

    var errorMessage = '';
  }
}
