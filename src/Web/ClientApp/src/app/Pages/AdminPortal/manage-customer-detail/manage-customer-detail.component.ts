import { Component } from '@angular/core';
import { UsersClient, UserByIDDto } from '../../../web-api-client';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-manage-customer-detail',
  templateUrl: './manage-customer-detail.component.html',
  styleUrls: ['./manage-customer-detail.component.css']
})
export class ManageCustomerDetailComponent {

  public userByIDDto: UserByIDDto[] = [];

  constructor(
    private usersClient: UsersClient,
    private router: Router,
    private route: ActivatedRoute,
  ) {
  }

  b_id?:any;
  b_avatar?:any;
  b_userName?:any;
  b_lastName?:any;
  b_firstName?:any;
  b_middleName?:any;
  b_emailAddress?:any;
  b_isAdminAccount?: boolean | undefined;
  b_street?:any;
  b_city?:any;
  b_province?:any;
  b_region?:any;
  b_zipCode?:any;
  b_contactNumber?:any;
  b_birthDate?:any;

  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
    var code_id = this.route.snapshot.paramMap.get('key');
    this.getUserById(code_id);
  }

  getUserById(userid: any): void {
    this.usersClient.getUserByID(userid).subscribe({
      next: result => {
        this.b_id = result.data?.id;
        this.b_avatar = result.data?.avatar;
        this.b_userName = result.data?.userName;
        this.b_lastName = result.data?.lastName;
        this.b_firstName = result.data?.firstName;
        this.b_middleName = result.data?.middleName;
        this.b_emailAddress = result.data?.emailAddress;
        this.b_isAdminAccount = result.data?.isAdminAccount;
        this.b_street = result.data?.street;
        this.b_city = result.data?.city;
        this.b_province = result.data?.province;
        this.b_region = result.data?.region;
        this.b_zipCode = result.data?.zipCode;
        this.b_contactNumber = result.data?.contactNumber;
        this.b_birthDate = result.data?.birthDate;
      },
      error: error => console.error(error)
    });
  }
}
