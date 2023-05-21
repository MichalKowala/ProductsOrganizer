import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { filter, map, Subject, switchMap, takeUntil } from "rxjs";
import { ProductsService } from "../../service/products.service";
import { Product } from "../../model/product";
import { ToastrService } from "ngx-toastr";
import { FormBuilder, FormControl, Validators } from "@angular/forms";

@Component({
  selector: 'app-create-or-update-product',
  templateUrl: './create-or-update-product.component.html',
  styleUrls: ['./create-or-update-product.component.css']
})
export class CreateOrUpdateProductComponent implements OnInit {
  product: Product;
  showErrors = false;
  ngUnsubscribe = new Subject<void>();

  formGroup = this.fb.group({
    code: new FormControl<string>('', {validators: [Validators.required, Validators.maxLength(5), Validators.minLength(5)]}),
    name: new FormControl<string>('', {validators: [Validators.required, Validators.maxLength(40), Validators.minLength(8)]}),
    description: new FormControl<string>('', {validators: Validators.maxLength(150)}),
    price: new FormControl<number | null>(null, {validators: [Validators.required, Validators.min(1)]})
  });

  constructor(
    private route: ActivatedRoute,
    private productsService: ProductsService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) {
  }

  ngOnInit(): void {
    this.route.params.pipe(
      takeUntil(this.ngUnsubscribe),
      map(params => params['id']),
      filter(id => !!id),
      switchMap(id => this.productsService.getProduct(id))
    ).subscribe({
      next: (product => {
        this.product = product;
        this.patchForm();
      })
    })
  }

  submit() {
    this.formGroup.markAllAsTouched();
    this.showErrors = true;
    if (!this.formGroup.valid) {
      return;
    }

  }

  private patchForm() {
    this.formGroup.patchValue({
      code: this.product.code,
      name: this.product.name,
      description: this.product.description,
      price: this.product.price
    })
  }
}
