import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/shared/models/product.model';
import { ProductBrand } from 'src/app/shared/models/productBrand.model';
import { ProductType } from 'src/app/shared/models/productType.model';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  productList: Product[];
  productBrandList: ProductBrand[];
  productTypeList: ProductType[];
  brandIdSelected = 0;
  typeIdSelected = 0;

  constructor(private _shopService: ShopService) {}

  ngOnInit(): void {
    this.getProductList();
    this.getProductBrandList();
    this.getProductTypeList();
  }

  getProductList() {
    this._shopService
      .getProductList(this.brandIdSelected, this.typeIdSelected)
      .subscribe({
        next: (res) => {
          this.productList = res?.data;
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
        this.productBrandList = [{ id: 0, name: 'All' }, ...res];
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  getProductTypeList() {
    this._shopService.getProductTypeList().subscribe({
      next: (res) => {
        this.productTypeList = [{ id: 0, name: 'All' }, ...res];
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
  onBrandSelected(brandId: number) {
    this.brandIdSelected = brandId;
    this.getProductList();
  }
  onTypeSelected(typeId: number) {
    this.typeIdSelected = typeId;
    this.getProductList();
  }
}
