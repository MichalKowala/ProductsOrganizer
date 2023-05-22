import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ProductsBrowserComponent } from './products/products-browser/products-browser.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from "@angular/material/table";
import { ToastrModule } from "ngx-toastr";
import { MatButtonModule } from "@angular/material/button";
import { CreateOrUpdateProductComponent } from './products/create-or-update-product/create-or-update-product.component';
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatPaginatorModule } from "@angular/material/paginator";

const MATERIAL = [
  MatTableModule,
  MatButtonModule,
  MatFormFieldModule,
  MatInputModule,
  MatPaginatorModule
]

@NgModule({
  declarations: [
    AppComponent,
    ProductsBrowserComponent,
    CreateOrUpdateProductComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {path: '', redirectTo: 'products', pathMatch: 'full'},
      {path: 'products', component: ProductsBrowserComponent},
      {path: 'products/new', component: CreateOrUpdateProductComponent},
      {path: 'products/:id/edit', component: CreateOrUpdateProductComponent},
      {path: '**', redirectTo: 'products'}
    ]),
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    ...MATERIAL,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
