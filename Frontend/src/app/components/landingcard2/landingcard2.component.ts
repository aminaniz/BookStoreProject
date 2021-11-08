import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BooksService } from 'src/app/services/books.service';

@Component({
  selector: 'app-landingcard2',
  templateUrl: './landingcard2.component.html',
  styleUrls: ['./landingcard2.component.css']
})
export class Landingcard2Component implements OnInit {

  books:any;
  books1:any;
  books2:any;
  books3:any;
  
  // image="https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/";
  constructor(private bookservice:BooksService,private router:Router) { }

  ngOnInit(): void {
   this.bookservice.getBooks().subscribe(res=>{
    console.log(res);

     this.books1=res.slice(0,4);
     this.books2=res.slice(5,9);
     this.books3=res.slice(10,14);
   })
  }
  bookdetails(BookName:any){
    this.router.navigate(['details',BookName])
  }

}
