import { Component } from '@angular/core';
import { UsersClient, CreateUserCommand} from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-client-register',
  templateUrl: './client-register.component.html',
  styleUrls: ['./client-register.component.css']
})
export class ClientRegisterComponent {

  constructor(
    private router: Router,
    private usersClient: UsersClient,
    private loader: SpinnerServiceService,
    private route: ActivatedRoute
  ) {
  }

  CreateUser(firstname: any, 
    lastname: any , 
    middlename: any, 
    contactnumber: any, 
    birthdate: any, 
    age: any, 
    street1: any, 
    street2: any, 
    city: any, 
    zip: any, 
    province: any, 
    emailaddress: any, 
    password: any, 
    confirmpassword: any){
      
    var errorMessage = '';
 
    const list = {
      "userName": emailaddress,
      "password": password,
      "lastName": lastname,
      "firstName": firstname,
      "middleName": middlename,
      "emailAddress": emailaddress,
      "street": street1 + " " + street2,
      "city": city,
      "province": province,
      "region": province,
      "zipCode": zip,
      "contactNumber": contactnumber,
      "birthDate": birthdate
    };

    $("#firstname").removeClass("haserror");
    $("#lastname").removeClass("haserror");
    $("#contactnumber").removeClass("haserror");
    $("#birthdate").removeClass("haserror");
    $("#street1").removeClass("haserror");
    $("#city").removeClass("haserror");
    $("#zip").removeClass("haserror");
    $("#emailaddress").removeClass("haserror");
    $("#password").removeClass("haserror");
    $("#confirmpassword").removeClass("haserror");

    if(firstname == ''){
      errorMessage += "Firstname is required<br>";
      $("#firstname").addClass("haserror");
    }

    if(lastname == ''){
      errorMessage += "Lastname is required<br>";
      $("#lastname").addClass("haserror");
    }

    if(contactnumber == ''){
      errorMessage += "Contact number is required<br>";
      $("#contactnumber").addClass("haserror");
    }

    if(birthdate == ''){
      errorMessage += "Birth date is required<br>";
      $("#birthdate").addClass("haserror");
    }

    if(street1 == ''){
      errorMessage += "Street is required<br>";
      $("#street1").addClass("haserror");
    }

    if(city == ''){
      errorMessage += "City is required<br>";
      $("#city").addClass("haserror");
    }

    if(zip == ''){
      errorMessage += "Zip code is required<br>";
      $("#zip").addClass("haserror");
    }

    if(emailaddress == ''){
      errorMessage += "Username/Email address is required<br>";
      $("#emailaddress").addClass("haserror");
    }

    if(password == ''){
      errorMessage += "Password is required<br>";
      $("#password").addClass("haserror");
    }

    if(confirmpassword == ''){
      errorMessage += "Confirm password is required<br>";
      $("#confirmpassword").addClass("haserror");
    }
  
    if(errorMessage == ''){
      this.usersClient.createIdentityUser(list as CreateUserCommand).subscribe(
        result => {
          if(result.resultType == 1){
            //this.loader.ShowToast("New Airport has been successfully added.", "success");
            this.router.navigate(['login/registration-confirmation']);
          }else{
            alert(result.message);
            //this.loader.DisplayErrorMessage(result.message);
            //this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
          }
        },
        error => {
          const errors = JSON.parse(error.response).errors;
          alert(errors);
          //this.loader.DisplayErrorMessage(errors);
          //this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
        }
      );
    }else{
      alert("Some fields are required.");
      //this.loader.DisplayErrorMessage(errorMessage);
      //this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
    }


  }

}
