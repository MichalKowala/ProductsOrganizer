import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";
import { filter, map, Subject, switchMap, takeUntil } from "rxjs";
import { ProductsService } from "../../service/products.service";
import { CreateProductRequest, Product, UpdateProductRequest } from "../../model/product";
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
    private toastr: ToastrService,
    private router: Router
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
    if (this.product?.id) {
      this.updateProduct();
      return;
    }
    this.createProduct();
  }

  private createProduct() {
    this.productsService.createProduct(this.getCreateProductRequest()).subscribe({
      next: (_) => {
        this.toastr.success('Product has been created');
        this.router.navigate(['products']);
      }
    })
  }

  private getCreateProductRequest(): CreateProductRequest {
    return {
      code: this.formGroup.controls.code.value!,
      name: this.formGroup.controls.name.value!,
      description: this.formGroup.controls.description.value!,
      price: this.formGroup.controls.price.value!
    };
  }

  private updateProduct() {
    this.productsService.updateProduct(this.getUpdateProductRequest()).subscribe({
      next: (_) => {
        this.toastr.success('Product has been updated');
        this.router.navigate(['products']);
      }
    })
  }

  private getUpdateProductRequest(): UpdateProductRequest {
    return {
      id: this.product.id,
      code: this.formGroup.controls.code.value!,
      name: this.formGroup.controls.name.value!,
      description: this.formGroup.controls.description.value!,
      price: this.formGroup.controls.price.value!
    };
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
