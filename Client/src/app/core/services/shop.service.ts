import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from 'src/app/shared/models/pagination.model';
import { ProductBrand } from 'src/app/shared/models/productBrand.model';
import { ProductType } from 'src/app/shared/models/productType.model';
import { environment as env } from '../../../environments/environment';
@Injectable({
  providedIn: 'root',
})
export class ShopService {
  constructor(private http: HttpClient) {}

  getProductList() {
    return this.http.get<Pagination>(env.ApiUrl + `products?pageSize=50`);
  }
  getProductBrandList() {
    return this.http.get<ProductBrand[]>(env.ApiUrl + `products/brands`);
  }
  getProductTypeList() {
    return this.http.get<ProductType[]>(env.ApiUrl + `products/types`);
  }
}
