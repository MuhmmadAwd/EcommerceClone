import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/shared/models/product.model';
import { ProductBrand } from 'src/app/shared/models/productBrand.model';
import { ProductType } from 'src/app/shared/models/productType.model';
import { ShopService } from '../../core/services/shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  productList?: Product[];
  productBrandList?: ProductBrand[];
  productTypeList?: ProductType[];

  constructor(private _shopService: ShopService) {}

  ngOnInit(): void {
    this.getProductList();
    this.getProductBrandList();
    this.getProductTypeList();
  }

  getProductList() {
    this._shopService.getProductList().subscribe({
      next: (res) => {
        this.productList = res.data;
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  getProductBrandList() {
    this._shopService.getProductBrandList().subscribe({
      next: (res) => {
        console.log(res);
        this.productBrandList = res;
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  getProductTypeList() {
    this._shopService.getProductTypeList().subscribe({
      next: (res) => {
        this.productTypeList = res;
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
