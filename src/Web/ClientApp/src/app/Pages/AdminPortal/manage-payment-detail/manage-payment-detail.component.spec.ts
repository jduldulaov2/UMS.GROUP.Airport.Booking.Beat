import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagePaymentDetailComponent } from './manage-payment-detail.component';

describe('ManagePaymentDetailComponent', () => {
  let component: ManagePaymentDetailComponent;
  let fixture: ComponentFixture<ManagePaymentDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManagePaymentDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManagePaymentDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
