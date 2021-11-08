import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { CartItem } from '../CartItem';
import { Address } from '../Address';
import { Wishlist } from 'src/app/Wishlist';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private Endpoints = {
    Customers_Url : "http://localhost:56412/api/customers",
    Books_Url:"http://localhost:56412/books",
    Status_Url:"http://localhost:56412/api/user/statuschange/",
    Cart_Url:"http://localhost:56412/cart/",
    empty_cart_Url:"http://localhost:56412/empty_cart/",
    place_order_Url:"http://localhost:56412/place_order/",
    Order_url:"http://localhost:56412/myOrder/",
    Address_url:"http://localhost:56412/ShippingAddress/",
    AddAddress_url:"http://localhost:56412/addAddress/",
    update_Address_url:"http://localhost:56412/updateAddress/",
    wishlist_url:"http://localhost:56412/add-wishlist/",
    get_wishlist_url:"http://localhost:56412/wishlist/",
    del_wishlist_url:"http://localhost:56412/delete-wishlist/"
  }

  constructor(private _http: HttpClient) { }

  getCustomers(): Observable<any>{
    return this._http.get<any>(this.Endpoints.Customers_Url);
  }

  getBooks(): Observable<any>{
    return this._http.get<any>(this.Endpoints.Books_Url);
  }

  changeStatus(id:any,status:any):Observable<any>{
    return this._http.put<any>(this.Endpoints.Status_Url+id+'/'+status,1)
  }

  getCartItems(userId: number):Observable<any>{
    return this._http.get<any>(this.Endpoints.Cart_Url+userId);
  }

  deleteCartItem(itemId:number):Observable<any>{
    return this._http.delete<any>(this.Endpoints.Cart_Url+itemId);  
  }

  updateCartItem(itemId:number, cartitem:CartItem):Observable<any>{
    return this._http.put<any>(this.Endpoints.Cart_Url+itemId, cartitem);
  }

  emptyCart(userId: number): Observable<any>{
    return this._http.delete<any>(this.Endpoints.empty_cart_Url+userId);
  }

  placeOrder(userId:number): Observable<any>{
    return this._http.get<any>(this.Endpoints.place_order_Url+userId);
  }

  getOrder(userId: number):Observable<any>{
    return this._http.get<any>(this.Endpoints.Order_url+userId)
  }

  getAdresses(userId: number):Observable<any>{
    return this._http.get<any>(this.Endpoints.Address_url+userId)
  }
  
  addAddress(address:Address){
    return this._http.post<any>(this.Endpoints.AddAddress_url, address)
  }

  updateAddess(userId:number, address:Address){
    return this._http.put<any>(this.Endpoints.update_Address_url, address)
  }

  getWishlist(userId: number){
    return this._http.get<any>(this.Endpoints.get_wishlist_url+userId)
  }

  deleteWishlist(wishId:number){
    return this._http.delete<any>(this.Endpoints.del_wishlist_url+wishId)
  }

  addToWishlist(wishlist:Wishlist, id:number){
    return this._http.post<any>(this.Endpoints.wishlist_url+id, wishlist);
  }
  

}