import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyCartFromBookingComponent } from './my-cart-from-booking.component';

describe('MyCartFromBookingComponent', () => {
  let component: MyCartFromBookingComponent;
  let fixture: ComponentFixture<MyCartFromBookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyCartFromBookingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyCartFromBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
