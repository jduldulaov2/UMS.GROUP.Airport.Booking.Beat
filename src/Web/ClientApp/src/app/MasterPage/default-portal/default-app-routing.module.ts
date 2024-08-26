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
import { ClientLoginConfirmationComponent }  from '../../Pages/ClientPortal/client-login-confirmation/client-login-confirmation.component';
import { MyCartFromBookingComponent }  from '../../Pages/ClientPortal/my-cart-from-booking/my-cart-from-booking.component';
import { FoodMenuFromBookingComponent }  from '../../Pages/ClientPortal/food-menu-from-booking/food-menu-from-booking.component';
import { UserActivityComponent }  from '../../Pages/ClientPortal/user-activity/user-activity.component';
import { CheckoutFromBookingComponent }  from '../../Pages/ClientPortal/checkout-from-booking/checkout-from-booking.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
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
  },
  {
    path: 'login/login-confirmation',
    component: ClientLoginConfirmationComponent
  },
  {
    path: 'my-cart/booking/:key/detail',
    component: MyCartFromBookingComponent
  },
  {
    path: 'food-menu/booking/:key/detail',
    component: FoodMenuFromBookingComponent
  }
  ,
  {
    path: 'my-activity',
    component: UserActivityComponent
  },
  {
    path: 'checkout/booking/:key/detail',
    component: CheckoutFromBookingComponent
  }
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class DefaultAppRoutingModule { }
