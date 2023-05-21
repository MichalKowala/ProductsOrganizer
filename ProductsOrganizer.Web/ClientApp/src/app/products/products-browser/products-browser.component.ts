import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/model/product';
import { ProductsService } from "../../service/products.service";
import { ToastrService } from "ngx-toastr";
import { catchError, EMPTY, switchMap, tap } from "rxjs";
import { Router } from "@angular/router";

@Component({
  selector: 'app-products-browser',
  templateUrl: './products-browser.component.html',
  styleUrls: ['./products-browser.component.css']
})
export class ProductsBrowserComponent implements OnInit {
  columnsToDisplay: string[] = ['code', 'name','description', 'price', 'actions'];
  products: Product[] = [];
  skip: number = 0;
  take: number = 10;
  constructor(
    private productsService: ProductsService,
    private toastrService: ToastrService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.productsService.getProducts(this.skip,this.take).subscribe({
      next: (products) => {
        this.products = products;
      },
      error: (err) => {
        console.error(err);
      }
    });
  }

  removeProduct(productId: string) {
    if (confirm('Are you sure you want to delete this product?')) {
      this.productsService.deleteProduct(productId).pipe(
        catchError((err) => {
          this.toastrService.error('An error occured while trying to delete the product');
          return EMPTY;
        }),
        tap(_ => {
          this.toastrService.success('Product has been deleted');
        }),
        switchMap(_ => this.productsService.getProducts(this.skip, this.take))
      ).subscribe({
        next: (products) => {
          this.products = products;
        }
      })
    }
  }

  redirectToEditOrCreate(productId?: string) {
    if (productId) {
      this.router.navigate(['products', productId, 'edit']);
    } else {
      this.router.navigate(['products', 'new']);
    }
  }
}
