import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { Product } from "../model/product";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  apiEndpoint :string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiEndpoint = baseUrl + 'api/products';
  }

  getRange(skip: number = 0, take: number = 5): Observable<Product[]> {
    let params = new HttpParams();
    params = params.set('skip', skip.toString());
    params = params.set('take', take.toString());
    return this.http.get<Product[]>(`${this.apiEndpoint}`, {params: params});
  }

  remove(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiEndpoint}/${id}`);
  }
}
