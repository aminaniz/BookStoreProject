import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CouponService {

  url={
    COUPONS:"http://localhost:56412/coupons",
    BOOKS:"http://localhost:56412/books/",
    ADDCOUPON:"http://localhost:56412/addcoupon",
    DELETECOUPON:"http://localhost:56412/deletecoupon/",
    UPDATECOUPON:"http://localhost:56412/updatecoupon/",
    STATUS:"http://localhost:56412/coupon/statuschange/"
  }
    constructor(private http:HttpClient) { }
    getCoupons() : Observable<any>{
      return this.http.get<any>(this.url.COUPONS)
     }

     addCoupon(coupon:any):Observable<any>{
      return this.http.post<any>(this.url.ADDCOUPON,coupon)
    }
 
    updateCoupon(coupon:any):Observable<any>{
     return this.http.put<any>(this.url.UPDATECOUPON,coupon)
   }
 
    deleteCoupon(id:any):Observable<any>{
      console.log(id);
      return this.http.delete<any>(this.url.DELETECOUPON+id)
    }

    changeStatus(id:any,status:any):Observable<any>{
      return this.http.put<any>(this.url.STATUS+id+'/'+status,1)
    }
}
