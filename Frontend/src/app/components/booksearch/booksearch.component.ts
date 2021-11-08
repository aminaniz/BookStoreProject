import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CartItem } from 'src/app/CartItem';
import { BooksService } from 'src/app/services/books.service';
import { DataService } from 'src/app/services/data.service';
import { Wishlist } from 'src/app/Wishlist';

@Component({
  selector: 'app-booksearch',
  templateUrl: './booksearch.component.html',
  styleUrls: ['./booksearch.component.css']
})
export class BooksearchComponent implements OnInit {

  books: any;
  search:any;
  searchtext: string | null;
  User: any;
  public cartItemModel = new CartItem();
  public wishlist = new Wishlist();
  
  constructor(private activateRoute:ActivatedRoute,private bookservice:BooksService,private router:Router,private _dataService:DataService) 
  {this.searchtext =  activateRoute.snapshot.paramMap.get('name');
  this.search =  activateRoute.snapshot.paramMap.get('type');
}
  ngOnInit(): void {
    
    this.bookservice.searchBookbyName(this.search,this.searchtext).subscribe(res=>{
      this.books=res;
      
    })
    this.User = localStorage.getItem('user');
    this.User = JSON.parse(this.User);
  }
  bookdetails(BookName:any){
    this.router.navigate(['details',BookName])
  }
  addToCart(book: any){

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
  addToWishlist(book:any){
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
