import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReserveATableComponent } from './reserve-atable.component';

describe('ReserveATableComponent', () => {
  let component: ReserveATableComponent;
  let fixture: ComponentFixture<ReserveATableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReserveATableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReserveATableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
