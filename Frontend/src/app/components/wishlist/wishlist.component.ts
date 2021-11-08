import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CartItem } from 'src/app/CartItem';
import { BooksService } from 'src/app/services/books.service';
import { DataService } from 'src/app/services/data.service';
import { Wishlist } from 'src/app/Wishlist';

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css']
})
export class WishlistComponent implements OnInit {

  User: any;
  listofWishlist:any;
  cartItemModel = new CartItem();


  constructor(private _dataService:DataService, private _router:Router, private bookservice: BooksService) 
  {}

  ngOnInit(): void {
    this.User = localStorage.getItem('user');
    this.User = JSON.parse(this.User);
    this._dataService.getWishlist(this.User.UserId).subscribe((data: any) => this.listofWishlist = data);
  }

  onDelete(wishId:number,index:number){
    this._dataService.deleteWishlist(wishId).subscribe(()=>{
      this.listofWishlist.splice(index, 1);
    });
  }

  addToCart(wishlist:Wishlist,wishId:number,index:number ){

      this.cartItemModel.BookId=wishlist.BookId;
      this.cartItemModel.UserId=this.User.UserId;
      this.cartItemModel.Price=wishlist.Price;
      this.cartItemModel.Quantity = 1;
      this.cartItemModel.Active=1;
      this.cartItemModel.Total = wishlist.Price;
      this.bookservice.AddCartItem(this.cartItemModel).subscribe(res =>{})
      this._dataService.deleteWishlist(wishId).subscribe(()=>{
        this.listofWishlist.splice(index, 1);
      });
    
  }

}
