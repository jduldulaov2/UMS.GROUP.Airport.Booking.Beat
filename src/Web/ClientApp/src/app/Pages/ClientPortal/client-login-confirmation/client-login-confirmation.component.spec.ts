import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientLoginConfirmationComponent } from './client-login-confirmation.component';

describe('ClientLoginConfirmationComponent', () => {
  let component: ClientLoginConfirmationComponent;
  let fixture: ComponentFixture<ClientLoginConfirmationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClientLoginConfirmationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientLoginConfirmationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
