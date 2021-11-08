import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
url={
  CATEGORY:"http://localhost:56412/categories",
  BOOKS:"http://localhost:56412/books/",
  ADDCAT:"http://localhost:56412/addcat",
  DELETECAT:"http://localhost:56412/deletecat/",
  UPDATECAT:"http://localhost:56412/updatecat/"
}
  constructor(private http:HttpClient) { }
  getCategories() : Observable<any>{
    return this.http.get<any>(this.url.CATEGORY)
   }

   findBooksbyId(id:any):Observable<any>{
     return this.http.get<any>(this.url.BOOKS+id)
   }

   addCategory(category:any):Observable<any>{
     return this.http.post<any>(this.url.ADDCAT,category)
   }

   updateCategory(category:any):Observable<any>{
    return this.http.put<any>(this.url.UPDATECAT,category)
  }

   deleteCategory(id:any):Observable<any>{
     console.log(id);
     return this.http.delete<any>(this.url.DELETECAT+id)
   }
}
