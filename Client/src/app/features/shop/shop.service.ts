import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from 'src/app/shared/models/pagination.model';
import { ProductBrand } from 'src/app/shared/models/productBrand.model';
import { ProductType } from 'src/app/shared/models/productType.model';
import { map } from 'rxjs/operators';
import { environment as env } from '../../../environments/environment';
@Injectable({
  providedIn: 'root',
})
export class ShopService {
  constructor(private http: HttpClient) {}

  getProductList(brandId: number, typeId: number) {
    let params = new HttpParams();

    if (brandId) {
      params = params.append('brandId', brandId.toString());
    }
    if (typeId) {
      params = params.append('typeId', typeId.toString());
    }
    return this.http
      .get<Pagination>(env.ApiUrl + `products`, { observe: 'response', params })
      .pipe(
        map((res) => {
          return res.body;
        })
      );
  }
  getProductBrandList() {
    return this.http.get<ProductBrand[]>(env.ApiUrl + `products/brands`);
  }
  getProductTypeList() {
    return this.http.get<ProductType[]>(env.ApiUrl + `products/types`);
  }
}
