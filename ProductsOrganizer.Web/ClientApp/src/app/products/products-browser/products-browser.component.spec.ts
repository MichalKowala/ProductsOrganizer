import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsBrowserComponent } from './products-browser.component';

describe('ProductsBrowserComponent', () => {
  let component: ProductsBrowserComponent;
  let fixture: ComponentFixture<ProductsBrowserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductsBrowserComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductsBrowserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
