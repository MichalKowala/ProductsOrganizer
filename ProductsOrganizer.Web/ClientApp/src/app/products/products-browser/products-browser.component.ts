import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Product } from 'src/app/model/product';
import { ProductsService } from "../../service/products.service";
import { ToastrService } from "ngx-toastr";
import { catchError, EMPTY, forkJoin, switchMap, tap } from "rxjs";
import { Router } from "@angular/router";

@Component({
  selector: 'app-products-browser',
  templateUrl: './products-browser.component.html',
  styleUrls: ['./products-browser.component.css']
})
export class ProductsBrowserComponent implements OnInit {
  columnsToDisplay: string[] = ['code', 'name','description', 'price', 'actions'];
  products: Product[] = [];
  totalProductsCount: number; //used by paginator

  skip: number = 0;
  pageSize: number = 10;

  constructor(
    private productsService: ProductsService,
    private toastrService: ToastrService,
    private router: Router,
    private cdr: ChangeDetectorRef
  ) {
  }

  ngOnInit(): void {
    forkJoin([
      this.productsService.getProductsCount(),
      this.productsService.getProducts(this.skip, this.pageSize)
    ]).subscribe({
      next: (([count, products]) => {
        this.totalProductsCount = count;
        this.products = products;
      })
    })
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
        switchMap(_ => this.productsService.getProducts(this.skip, this.pageSize))
      ).subscribe({
        next: (products) => {
          this.totalProductsCount--;
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

  onPaginatorClicked(event: any) {
    this.skip = this.pageSize * event.pageIndex;
    this.productsService.getProducts(this.skip, this.pageSize).subscribe({
      next: (products) => {
        this.products = products;
        this.cdr.markForCheck();
      }
    })
  }
}
