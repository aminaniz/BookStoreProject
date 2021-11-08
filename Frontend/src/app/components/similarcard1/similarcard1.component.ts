import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BooksService } from 'src/app/services/books.service';

@Component({
  selector: 'app-similarcard1',
  templateUrl: './similarcard1.component.html',
  styleUrls: ['./similarcard1.component.css']
})
export class Similarcard1Component implements OnInit {
  books:any;
  books1:any;
  books2:any;
  books3:any;
  
  // image="https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/";
  constructor(private bookservice:BooksService,private router:Router) { }

  ngOnInit(): void {
   this.bookservice.getBooks().subscribe(res=>{
    console.log(res);

     this.books1=res.slice(30,36);
     this.books2=res.slice(40,46);
     this.books3=res.slice(20,26);
   })
  }
  bookdetails(BookName:any){
    this.router.navigate(['details',BookName])
  }

}
