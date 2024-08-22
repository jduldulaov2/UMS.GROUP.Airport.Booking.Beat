import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageBookingDetailComponent } from './manage-booking-detail.component';

describe('ManageBookingDetailComponent', () => {
  let component: ManageBookingDetailComponent;
  let fixture: ComponentFixture<ManageBookingDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageBookingDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageBookingDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
