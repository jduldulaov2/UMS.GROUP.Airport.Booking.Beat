import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageTableDetailComponent } from './manage-table-detail.component';

describe('ManageTableDetailComponent', () => {
  let component: ManageTableDetailComponent;
  let fixture: ComponentFixture<ManageTableDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageTableDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageTableDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
