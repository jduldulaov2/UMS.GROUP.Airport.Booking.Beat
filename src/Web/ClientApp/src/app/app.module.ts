import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {RouterModule, Routes} from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { TopMenuComponent } from './top-menu/top-menu.component';
import { FooterMenuComponent } from './footer-menu/footer-menu.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HighchartsChartModule } from 'highcharts-angular';
import { PreLoaderComponent } from './Shared/pre-loader/pre-loader.component';
import { SidebarComponent } from './Shared/sidebar/sidebar.component';
import { HeaderComponent } from './Shared/header/header.component';
import { FooterComponent } from './Shared/footer/footer.component';
import { AdminAppRoutingModule } from './MasterPage/admin-portal/admin-app-routing.module';
import { AdminPortalComponent } from './MasterPage/admin-portal/admin-portal.component';
import { DefaultPortalComponent } from './MasterPage/default-portal/default-portal.component';
import { DefaultAppRoutingModule } from './MasterPage/default-portal/default-app-routing.module';
import { SpinnerComponent } from './Shared/spinner/spinner.component';
import { DashboardComponent } from './Pages/AdminPortal/dashboard/dashboard.component';
import { ManageBookingComponent } from './Pages/AdminPortal/manage-booking/manage-booking.component';
import { ManageOrderComponent } from './Pages/AdminPortal/manage-order/manage-order.component';
import { ManagePaymentComponent } from './Pages/AdminPortal/manage-payment/manage-payment.component';
import { MenuListPreviewComponent } from './Pages/AdminPortal/menu-list-preview/menu-list-preview.component';
import { ManageCustomerComponent } from './Pages/AdminPortal/manage-customer/manage-customer.component';
import { ManageRoleComponent } from './Pages/AdminPortal/manage-role/manage-role.component';
import { ManageFoodItemComponent } from './Pages/AdminPortal/manage-food-item/manage-food-item.component';
import { ManagePromoComponent } from './Pages/AdminPortal/manage-promo/manage-promo.component';
import { ManageCalendarComponent } from './Pages/AdminPortal/manage-calendar/manage-calendar.component';
import { ManageBookingDetailComponent } from './Pages/AdminPortal/manage-booking-detail/manage-booking-detail.component';
import { ManageFoodCategoryComponent } from './Pages/AdminPortal/manage-food-category/manage-food-category.component';
import { ManageCustomerDetailComponent } from './Pages/AdminPortal/manage-customer-detail/manage-customer-detail.component';
import { FoodMenuComponent }  from './Pages/ClientPortal/food-menu/food-menu.component';
import { CheckoutComponent }  from './Pages/ClientPortal/checkout/checkout.component';
import { LoginComponent }  from './Pages/ClientPortal/login/login.component';
import { ClientRegisterComponent }  from './Pages/ClientPortal/client-register/client-register.component';
import { ClientRegistrationConfirmationComponent }  from './Pages/ClientPortal/client-registration-confirmation/client-registration-confirmation.component';
import { ClientLoginConfirmationComponent }  from './Pages/ClientPortal/client-login-confirmation/client-login-confirmation.component';
import { MyCartFromBookingComponent }  from './Pages/ClientPortal/my-cart-from-booking/my-cart-from-booking.component';
import { FoodMenuFromBookingComponent }  from './Pages/ClientPortal/food-menu-from-booking/food-menu-from-booking.component';
import { HeaderClientComponent } from './Shared/header-client/header-client.component';
import { SidebarClientComponent } from './Shared/sidebar-client/sidebar-client.component';
import { FooterClientComponent } from './Shared/footer-client/footer-client.component';
import { UserActivityComponent }  from './Pages/ClientPortal/user-activity/user-activity.component';
import { CheckoutFromBookingComponent }  from './Pages/ClientPortal/checkout-from-booking/checkout-from-booking.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    TopMenuComponent,
    HomeComponent,
    LoginComponent,
    PreLoaderComponent,
    SidebarComponent,
    HeaderComponent,
    FooterComponent,
    AdminPortalComponent,
    DefaultPortalComponent,
    SpinnerComponent,
    FooterMenuComponent,
    DashboardComponent,
    ManageBookingComponent,
    ManageOrderComponent,
    ManagePaymentComponent,
    MenuListPreviewComponent,
    ManageCustomerComponent,
    ManageRoleComponent,
    ManageFoodItemComponent,
    ManagePromoComponent,
    ManageCalendarComponent,
    ManageBookingDetailComponent,
    ManageFoodCategoryComponent,
    ManageCustomerDetailComponent,
    FoodMenuComponent,
    CheckoutComponent,
    ClientRegisterComponent,
    ClientRegistrationConfirmationComponent,
    ClientLoginConfirmationComponent,
    MyCartFromBookingComponent,
    FoodMenuFromBookingComponent,
    HeaderClientComponent,
    SidebarClientComponent,
    FooterClientComponent,
    UserActivityComponent,
    CheckoutFromBookingComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    HighchartsChartModule,
    BrowserAnimationsModule,
    ModalModule.forRoot(),
    AdminAppRoutingModule,
    DefaultAppRoutingModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
