import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import {Router} from '@angular/router';
import { CartItem } from 'src/app/CartItem';
import { CouponService } from 'src/app/services/coupon.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  User:any;
  Orders:any;
  totalamount:number=0;
  CartItems:any;
  total:number=0;
  coupons:any;
  coupon:any;
  discount=false;
  msg:any;
  newprice:any;

  getTotal() {
    let total = 0;
    for (let cart of this.CartItems) {
      total+=cart.Total;
    }
    
    this.totalamount = total;
    console.log(this.totalamount);
  }

  getCoupon(tag:string){
    for(let coupon of this.coupons){
  
      // console.log(tag.length,'0',(coupon.Tag).replaceAll(/\s/g,''))
      // console.log((coupon.Tag).replaceAll(/\s/g,'')== (tag).normalize());
      if((coupon.Tag).replaceAll(/\s/g,'')== (tag).normalize()){
        // console.log(coupon);
        this.coupon=coupon;
        this.onRedeem(coupon);
      }    
    }
  }
  count(){
    return Object.keys(this.CartItems).length;
  }

  constructor(private _dataService:DataService, private _router:Router ,private couponservice:CouponService ) { }

  ngOnInit(): void {
    this.User = localStorage.getItem('user');
    this.User = JSON.parse(this.User);
    this._dataService.getCartItems(this.User.UserId).subscribe((data: any) => this.CartItems = data);  
    this.couponservice.getCoupons().subscribe(res=>{
      this.coupons=res;
     
    })
   
  }

  placeOrder(userId:number){
    this._dataService.placeOrder(userId).subscribe();
    // this._dataService.emptyCart(userId).subscribe();
    
  }

  
  onRedeem(coupon:any){
    // var today = new Date();
    // var dd = String(today.getDate()).padStart(2, '0');
    // var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    // var yyyy = today.getFullYear();
    // today1 = mm + '/' + dd + '/' + yyyy;

    // console.log(this.coupon+'jo');
    var l=new Date(this.coupon.ExpiryDate).toLocaleDateString();
    var g1=new Date(Number(l.slice(6,10)),Number(l.slice(3,5)),Number(l.slice(0,2)));
    var g2=new Date(2021,12,23);
    console.log(this.coupon.MinAmount,l)
    // var l=new Date(this.coupon.ExpiryDate).toLocaleDateString();
    if(this.coupon.MinAmount>=this.totalamount && g1>=g2){
        // console.log('true');
        this.msg='Coupon Applied';
        this.discount=true;
      
        this.newprice=this.totalamount-((this.totalamount)*this.coupon.Discount)/100;

    }
    else{
      this.msg='Invalid coupon';
      this.discount=false;;
      console.log('false');
    }
      

  }
}
