import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../Models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private _baseUrl: string = "webapi";

  constructor(private http: HttpClient) { }

  listaProdutos(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this._baseUrl}/product`);
  }
}
