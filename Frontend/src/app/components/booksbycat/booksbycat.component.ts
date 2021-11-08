import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, ParamMap, Router } from '@angular/router'
import { CartItem } from 'src/app/CartItem';
import { BooksService } from 'src/app/services/books.service';
import {book} from 'src/app/book'
import { Wishlist } from 'src/app/Wishlist';
import { DataService } from 'src/app/services/data.service';
@Component({
  selector: 'app-booksbycat',
  templateUrl: './booksbycat.component.html',
  styleUrls: ['./booksbycat.component.css']
})
export class BooksbycatComponent implements OnInit {
books:any;
catId:any;
image="https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/";
User: any;
public cartItemModel = new CartItem();
public wishlist = new Wishlist();



  constructor(private activateRoute:ActivatedRoute,private bookservice:BooksService,private router:Router,private _dataService:DataService) 
  {
    //this.catId =  activateRoute.snapshot.paramMap.get('id');
 }

  ngOnInit() {
    this.activateRoute.paramMap.subscribe((params:ParamMap)=>{
      if(params.has('id')){
        let id=parseInt(params.get('id')||'');
        this.catId=id;
        console.log(this.catId);
        this.bookservice.findBooksbyId(this.catId).subscribe(res=>{
          // window.location.reload();
          this.books=res;
          // this.User = localStorage.getItem('user');
          // this.User = JSON.parse(this.User);
        })
        
      }
     
    });
    this.User = localStorage.getItem('user');
    this.User = JSON.parse(this.User);
    //     this.bookservice.findBooksbyId(this.catId).subscribe(res=>{
    //   // window.location.reload();
    //   this.books=res;
     
    // })
  }
load():void{
  window.location.reload();
}
  bookdetails(BookName:any){
    
    this.router.navigate(['details',BookName])
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
    this._dataService.addToWishlist(this.wishlist, this.User.UserId).subscribe();
  }
  else{
    console.log("yes");
    this.router.navigate(['login'])
  }
}
}
