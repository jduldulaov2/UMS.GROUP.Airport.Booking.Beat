import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagePromoComponent } from './manage-promo.component';

describe('ManagePromoComponent', () => {
  let component: ManagePromoComponent;
  let fixture: ComponentFixture<ManagePromoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManagePromoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManagePromoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
