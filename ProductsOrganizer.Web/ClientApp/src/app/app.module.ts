import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ProductsBrowserComponent } from './products/products-browser/products-browser.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from "@angular/material/table";
import { ToastrModule } from "ngx-toastr";
import { MatButtonModule } from "@angular/material/button";

const MATERIAL = [
  MatTableModule,
  MatButtonModule
]

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProductsBrowserComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'products', pathMatch: 'full'},
      { path: 'products', component: ProductsBrowserComponent },
      { path: '**', redirectTo: 'products' }
    ]),
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    ...MATERIAL
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
