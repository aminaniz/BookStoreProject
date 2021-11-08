import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpErrorResponse} from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private Endpoints = {
    Register_Url: "http://localhost:56412/api/register",
    Login_Url: "http://localhost:56412/api/user/login",
    AdminLogin_Url: "http://localhost:56412/admin/login",
  }
  constructor(private _http:HttpClient) { }


  register(data:any):Observable<any>{
    return this._http.post<any>(this.Endpoints.Register_Url, data)}

    login(data: any): Observable<any>{
      return this._http.post<any>(this.Endpoints.Login_Url, data);    
    }

    adminlogin(data: any): Observable<any>{
      return this._http.post<any>(this.Endpoints.AdminLogin_Url, data);    
    }
    loggedIn(): boolean{
      if(localStorage.getItem("token")){
        return true;
      }else{
        return false;
      }
    }
    adminloggedIn():boolean{
      if(localStorage.getItem("admintoken")){
        return true;
      }else{
        return false;
      }
    }
}


