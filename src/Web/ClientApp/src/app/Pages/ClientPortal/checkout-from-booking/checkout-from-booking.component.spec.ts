import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckoutFromBookingComponent } from './checkout-from-booking.component';

describe('CheckoutFromBookingComponent', () => {
  let component: CheckoutFromBookingComponent;
  let fixture: ComponentFixture<CheckoutFromBookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CheckoutFromBookingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CheckoutFromBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
