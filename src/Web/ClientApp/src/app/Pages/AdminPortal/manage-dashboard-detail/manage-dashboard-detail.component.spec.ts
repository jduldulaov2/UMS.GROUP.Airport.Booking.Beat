import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageDashboardDetailComponent } from './manage-dashboard-detail.component';

describe('ManageDashboardDetailComponent', () => {
  let component: ManageDashboardDetailComponent;
  let fixture: ComponentFixture<ManageDashboardDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageDashboardDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageDashboardDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
