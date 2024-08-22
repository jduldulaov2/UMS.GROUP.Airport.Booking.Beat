import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuListPreviewComponent } from './menu-list-preview.component';

describe('MenuListPreviewComponent', () => {
  let component: MenuListPreviewComponent;
  let fixture: ComponentFixture<MenuListPreviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MenuListPreviewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MenuListPreviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
