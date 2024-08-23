import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { DefaultPortalComponent } from '../../MasterPage/default-portal/default-portal.component';
import { HomeComponent } from '../../home/home.component';
import { AboutComponent }  from '../../Pages/ClientPortal/about/about.component';
import { FoodMenuComponent }  from '../../Pages/ClientPortal/food-menu/food-menu.component';
import { SpecialMenuComponent }  from '../../Pages/ClientPortal/special-menu/special-menu.component';
import { ContactUsComponent }  from '../../Pages/ClientPortal/contact-us/contact-us.component';
import { MyCartComponent }  from '../../Pages/ClientPortal/my-cart/my-cart.component';
import { ReserveATableComponent }  from '../../Pages/ClientPortal/reserve-atable/reserve-atable.component';
import { CheckoutComponent }  from '../../Pages/ClientPortal/checkout/checkout.component';
import { LoginComponent }  from '../../Pages/ClientPortal/login/login.component';
import { ClientRegisterComponent }  from '../../Pages/ClientPortal/client-register/client-register.component';
import { ClientRegistrationConfirmationComponent }  from '../../Pages/ClientPortal/client-registration-confirmation/client-registration-confirmation.component';

const routes: Routes = [
  { 
    path: 'home', 
    component: HomeComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'about-us',
    component: AboutComponent
  },
  {
    path: 'food-menu',
    component: FoodMenuComponent
  },
  {
    path: 'special-menu',
    component: SpecialMenuComponent
  },
  {
    path: 'contact-us',
    component: ContactUsComponent
  },
  {
    path: 'my-cart',
    component: MyCartComponent
  },
  {
    path: 'reserve-a-table',
    component: ReserveATableComponent
  },
  {
    path: 'checkout',
    component: CheckoutComponent
  },
  {
    path: 'login/registration',
    component: ClientRegisterComponent
  },
  {
    path: 'login/registration-confirmation',
    component: ClientRegistrationConfirmationComponent
  }
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class DefaultAppRoutingModule { }
