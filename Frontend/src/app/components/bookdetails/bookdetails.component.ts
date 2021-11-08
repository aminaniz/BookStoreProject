import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { BooksService } from 'src/app/services/books.service';
import {book} from 'src/app/book'
import { CartItem } from 'src/app/CartItem';
import { DataService } from 'src/app/services/data.service';
import { Wishlist } from 'src/app/Wishlist';

@Component({
  selector: 'app-bookdetails',
  templateUrl: './bookdetails.component.html',
  styleUrls: ['./bookdetails.component.css']
})
export class BookdetailsComponent implements OnInit {
  BookName:any;
  book:any;
  public cartItemModel = new CartItem();
  User:any;
  wishlist=new Wishlist();

  constructor(private activateRoute:ActivatedRoute,private bookservice:BooksService,private router:Router,private dataService:DataService) 
  {
//     this.BookName =  activateRoute.snapshot.paramMap.get('name');
// console.log(this.BookName) 
}

  ngOnInit(): void {
 

    this.activateRoute.paramMap.subscribe((params:ParamMap)=>{
      if(params.has('name')){
        this.BookName=params.get('name')||'';      
        this.bookservice.findBooksbyName(this.BookName).subscribe(res=>{
          this.book=res;    
        })
        
      }
     
    });
    this.User = localStorage.getItem('user');
    this.User = JSON.parse(this.User);
  }
  addToCart(book: book){

    if(localStorage.getItem("token")!=null){
      console.log("no");
      this.cartItemModel.BookId=book.BookId;
      this.cartItemModel.UserId=this.User.UserId;
      this.cartItemModel.Price=book.Price;
      this.cartItemModel.Quantity = 1;
      this.cartItemModel.Active=1;
      this.cartItemModel.Total = book.Price;
      console.log(this.cartItemModel + 'jnj');
      this.bookservice.AddCartItem(this.cartItemModel).subscribe(res =>{})
    }else{
      console.log("yes");
      this.router.navigate(['login'])
    }
    
  }


  addToWishlist(book:book){
    if(localStorage.getItem("token")!=null){
    this.wishlist.UserId = this.User.UserId;
    this.wishlist.BookId = book.BookId;
    console.log(this.wishlist);
    this.dataService.addToWishlist(this.wishlist, this.User.UserId).subscribe();
  }
  else{
    console.log("yes");
    this.router.navigate(['login'])
  }
}
}
