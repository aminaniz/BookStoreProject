import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import {Router} from '@angular/router';
import { CartItem } from 'src/app/CartItem';
import { conditionallyCreateMapObjectLiteral } from '@angular/compiler/src/render3/view/util';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  User:any;
  randomCart:any;
  CartItems:any;
  totalamount:number=0;
  noCart:any;
  yesCart:any;
  getTotal() {
    let total = 0;
    for (let cartItem of this.CartItems) {
      total+=cartItem.Total;
    }
    this.totalamount = total;
    console.log(this.totalamount);
}

  constructor(private _dataService:DataService, private _router:Router  ) { }
  count(){
    return Object.keys(this.CartItems).length;
  }

  ngOnInit() {
    this.User = localStorage.getItem('user');
    this.User = JSON.parse(this.User);
    this._dataService.getCartItems(this.User.UserId).subscribe((data: any) => this.CartItems = data);
    this.getTotal();
     let count1=this.count();
     console.log(count1);
     if(count1==0){
       this.noCart=true;
     }
     else{
       this.yesCart=true;
     }
  }

  CartItemDelete(itemId:number, index:number){
    if(confirm("Are you sure to delete? ")) {
      
      this._dataService.deleteCartItem(itemId).subscribe(()=>{
        this.CartItems.splice(index, 1);
      });
      
    }
  }

  UpdatItemQuantity(itemId:number, cartItem:CartItem){
    if(confirm("Are you sure to Update? ")) {
      for (let cartItem of this.CartItems) {
        cartItem.Total=cartItem.Price*cartItem.Quantity;
      }
      this._dataService.updateCartItem(itemId,cartItem).subscribe();
      
    }
  }

  placeOrder(userId:number){
    this._dataService.placeOrder(userId).subscribe();
    // this._dataService.emptyCart(userId).subscribe();
    
  }

}
