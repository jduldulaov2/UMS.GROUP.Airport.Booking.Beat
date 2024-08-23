import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FoodMenuFromBookingComponent } from './food-menu-from-booking.component';

describe('FoodMenuFromBookingComponent', () => {
  let component: FoodMenuFromBookingComponent;
  let fixture: ComponentFixture<FoodMenuFromBookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FoodMenuFromBookingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FoodMenuFromBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
