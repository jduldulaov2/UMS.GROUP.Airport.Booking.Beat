import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageCustomerDetailComponent } from './manage-customer-detail.component';

describe('ManageCustomerDetailComponent', () => {
  let component: ManageCustomerDetailComponent;
  let fixture: ComponentFixture<ManageCustomerDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageCustomerDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageCustomerDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
