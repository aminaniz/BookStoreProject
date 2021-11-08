import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  url={
    BOOKSID:"http://localhost:56412/booksid/",
    BOOKS:"http://localhost:56412/books/",
    BOOKDET:"http://localhost:56412/details/",
    SEARCH:"http://localhost:56412/search/",
    BOOKUPDATE:"http://localhost:56412/updatebook/",
    BOOKADD:"http://localhost:56412/addbook",
    add_to_cart: "http://localhost:56412/add-to-cart"
  }
    constructor(private http:HttpClient) { }
    getBooks() : Observable<any>{
      return this.http.get<any>(this.url.BOOKS)
     }
     findBooksbyId(id:any):Observable<any>{
      return this.http.get<any>(this.url.BOOKSID+id)
    }
    findBooksbyName(name:any):Observable<any>{
      return this.http.get<any>(this.url.BOOKDET+name)
    }
    searchBookbyName(name:any,searchtext:any):Observable<any>{
      return this.http.get<any>(this.url.SEARCH+searchtext+'/'+name)
    }
    updateBook(book:any):Observable<any>{
      return this.http.put<any>(this.url.BOOKUPDATE,book)
    }
    addBook(book:any):Observable<any>{
      return this.http.post<any>(this.url.BOOKADD,book)
    }

    AddCartItem(CartItem:any):Observable<any>{
      console.log(CartItem);
      return this.http.post<any>(this.url.add_to_cart, CartItem)
    }


}

