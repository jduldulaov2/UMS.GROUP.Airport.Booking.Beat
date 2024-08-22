import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageFoodItemComponent } from './manage-food-item.component';

describe('ManageFoodItemComponent', () => {
  let component: ManageFoodItemComponent;
  let fixture: ComponentFixture<ManageFoodItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageFoodItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageFoodItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
