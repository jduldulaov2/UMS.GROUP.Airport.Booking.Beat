import { Component } from '@angular/core';
import { UsersClient, UsersListDto, UsersDto } from '../../../web-api-client';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-manage-customer',
  templateUrl: './manage-customer.component.html',
  styleUrls: ['./manage-customer.component.css']
})
export class ManageCustomerComponent {

  
  public usersDto: UsersDto[] = [];
  public usersListDto: UsersListDto;

  constructor(
    private usersClient: UsersClient
  ) {
  }

  ngOnInit(){
    $("html, body").animate({ scrollTop: 0 }, "fast");
    this.getUserListListByName('','1','1000');
  }

  getUserListListByName(name: any, page1: any, page2:any): void {
    this.usersClient.allUsersByName(name, page1, page2).subscribe({
      next: result => {
        this.usersDto = result.data?.users!;
        console.log(this.usersDto);
      },
      error: error => console.error(error)
    });
  }

}
