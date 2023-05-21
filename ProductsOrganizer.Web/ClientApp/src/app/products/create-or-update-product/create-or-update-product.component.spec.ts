import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateOrUpdateProductComponent } from './create-or-update-product.component';

describe('CreateOrUpdateProductComponent', () => {
  let component: CreateOrUpdateProductComponent;
  let fixture: ComponentFixture<CreateOrUpdateProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateOrUpdateProductComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateOrUpdateProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
