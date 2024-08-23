import { Component } from '@angular/core';
import { UsersClient, CreateUserCommand} from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { ActivatedRoute, Router } from '@angular/router';

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


    if(firstname == ''){
      errorMessage += "Firstname is required<br>";
    }

    if(lastname == ''){
      errorMessage += "Lastname is required<br>";
    }

    if(contactnumber == ''){
      errorMessage += "Contact number is required<br>";
    }

    if(birthdate == ''){
      errorMessage += "Birth date is required<br>";
    }

    if(street1 == ''){
      errorMessage += "Street is required<br>";
    }

    if(city == ''){
      errorMessage += "City is required<br>";
    }

    if(zip == ''){
      errorMessage += "Zip code is required<br>";
    }

    if(emailaddress == ''){
      errorMessage += "Username/Email address is required<br>";
    }

    if(password == ''){
      errorMessage += "Password is required<br>";
    }

    if(confirmpassword == ''){
      errorMessage += "Confirm password is required<br>";
    }
  
    if(errorMessage == ''){
      this.usersClient.createIdentityUser(list as CreateUserCommand).subscribe(
        result => {
          alert(result.resultType);
          if(result.resultType == 1){
            //this.loader.ShowToast("New Airport has been successfully added.", "success");
            //this.router.navigate(['/portal/manage-airport',result.data?.id,'detail']);
          }else{
            //this.loader.DisplayErrorMessage(result.message);
            //this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
          }
        },
        error => {
          const errors = JSON.parse(error.response).errors;
          //this.loader.DisplayErrorMessage(errors);
          //this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
        }
      );
    }else{
      alert(errorMessage);
      //this.loader.DisplayErrorMessage(errorMessage);
      //this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
    }


  }

}
