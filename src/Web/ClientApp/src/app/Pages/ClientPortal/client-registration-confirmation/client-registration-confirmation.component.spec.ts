import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientRegistrationConfirmationComponent } from './client-registration-confirmation.component';

describe('ClientRegistrationConfirmationComponent', () => {
  let component: ClientRegistrationConfirmationComponent;
  let fixture: ComponentFixture<ClientRegistrationConfirmationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClientRegistrationConfirmationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientRegistrationConfirmationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
