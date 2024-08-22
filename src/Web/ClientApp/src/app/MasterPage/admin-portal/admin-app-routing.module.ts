import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AdminPortalComponent } from '../../MasterPage/admin-portal/admin-portal.component';
import { DashboardComponent } from '../../Pages/AdminPortal/dashboard/dashboard.component';
import { ManageBookingComponent } from '../../Pages/AdminPortal/manage-booking/manage-booking.component';
import { ManageOrderComponent } from '../../Pages/AdminPortal/manage-order/manage-order.component';
import { ManagePaymentComponent } from '../../Pages/AdminPortal/manage-payment/manage-payment.component';
import { MenuListPreviewComponent } from '../../Pages/AdminPortal/menu-list-preview/menu-list-preview.component';
import { ManageCustomerComponent } from '../../Pages/AdminPortal/manage-customer/manage-customer.component';
import { ManageRoleComponent } from '../../Pages/AdminPortal/manage-role/manage-role.component';
import { ManageFoodItemComponent } from '../../Pages/AdminPortal/manage-food-item/manage-food-item.component';
import { ManagePromoComponent } from '../../Pages/AdminPortal/manage-promo/manage-promo.component';
import { ManageCalendarComponent } from '../../Pages/AdminPortal/manage-calendar/manage-calendar.component';
import { ManageBookingDetailComponent } from '../../Pages/AdminPortal/manage-booking-detail/manage-booking-detail.component';
import { ManageOrderDetailComponent } from '../../Pages/AdminPortal/manage-order-detail/manage-order-detail.component';
import { ManagePaymentDetailComponent } from '../../Pages/AdminPortal/manage-payment-detail/manage-payment-detail.component';
import { ManageFoodCategoryComponent } from '../../Pages/AdminPortal/manage-food-category/manage-food-category.component';
import { ManageCustomerDetailComponent } from '../../Pages/AdminPortal/manage-customer-detail/manage-customer-detail.component';
import { ManageTableDetailComponent } from '../../Pages/AdminPortal/manage-table-detail/manage-table-detail.component';
// import { AirportDetailComponent } from '../../Pages/BookingPortal/airport-detail/airport-detail.component';
// import { AirportDetailComponent } from '../../Pages/BookingPortal/airport-detail/airport-detail.component';
// import { AirportDetailComponent } from '../../Pages/BookingPortal/airport-detail/airport-detail.component';
// import { AirportDetailComponent } from '../../Pages/BookingPortal/airport-detail/airport-detail.component';

const routes: Routes = [
  {
    path: 'admin/my-dashboard',
    component: DashboardComponent
  },
  {
    path: 'admin/manage-booking',
    component: ManageBookingComponent
  },
  {
    path: 'admin/manage-order',
    component: ManageOrderComponent
  },
  {
    path: 'admin/manage-payment',
    component: ManagePaymentComponent
  },
  {
    path: 'admin/menu-list-preview',
    component: MenuListPreviewComponent
  },
  {
    path: 'admin/manage-customer',
    component: ManageCustomerComponent
  },
  {
    path: 'admin/manage-role',
    component: ManageRoleComponent
  },
  {
    path: 'admin/manage-food-item',
    component: ManageFoodItemComponent
  },
  {
    path: 'admin/manage-promo',
    component: ManagePromoComponent
  },
  {
    path: 'admin/manage-calendar',
    component: ManageCalendarComponent
  },
  {
    path: 'admin/manage-booking/:key/detail',
    component: ManageBookingDetailComponent
  },
  {
    path: 'admin/manage-order/:key/detail',
    component: ManageOrderDetailComponent
  },
  {
    path: 'admin/manage-payment/:key/detail',
    component: ManagePaymentDetailComponent
  },
  {
    path: 'admin/manage-food-category',
    component: ManageFoodCategoryComponent
  },
  {
    path: 'admin/manage-customer/:key/detail',
    component: ManageCustomerDetailComponent
  },
  {
    path: 'admin/manage-table',
    component: ManageTableDetailComponent
  }

  // {
  //   path: 'portal/manage-airport/:key/detail',
  //   component: AirportDetailComponent
  // },
  // {
  //   path: 'portal/manage-airport/register',
  //   component: AirportDetailComponent
  // },
  // {
  //   path: 'portal/manage-planes',
  //   component: PlaneListComponent
  // },
  // {
  //   path: 'portal/manage-flights',
  //   component: FlightListComponent
  // },
  // {
  //   path: 'portal/manage-bookings',
  //   component: BookingListComponent
  // },
  // {
  //   path: 'portal/manage-bookings/:key/detail',
  //   component: BookingDetailComponent
  // },
  // {
  //   path: 'portal/manage-bookings/register-booking',
  //   component: BookingDetailComponent
  // },
  // {
  //   path: 'portal/manage-planes/:key/detail',
  //   component: PlaneDetailComponent
  // },
  // {
  //   path: 'portal/manage-flights/:key/detail',
  //   component: FlightDetailComponent
  // },
  // {
  //   path: 'portal/manage-planes/register-airline',
  //   component: PlaneDetailComponent
  // },
  // {
  //   path: 'portal/manage-flights/register-flight',
  //   component: FlightDetailComponent
  // },
  // {
  //   path: 'portal/blank-page',
  //   component: BlankPageComponent
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AdminAppRoutingModule { }
