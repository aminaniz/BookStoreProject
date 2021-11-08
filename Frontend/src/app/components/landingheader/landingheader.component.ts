import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BooksService} from 'src/app/services/books.service'

@Component({
  selector: 'app-landingheader',
  templateUrl: './landingheader.component.html',
  styleUrls: ['./landingheader.component.css']
})
export class LandingheaderComponent implements OnInit {
search:any;
searchtext:any;
books:any;
  constructor(private bookservice:BooksService,private router:Router) {var search:string="book"; }

  ngOnInit(): void {
    var search:string="Search by";

  }
  changesearch(sid:any):void{
    if(sid==1){
      this.search="book";
    }
    else if(sid==2){
      this.search="author"
    }
    else if(sid==2){
      this.search="category"
    }
    else{
      this.search="isbn"
    }
  }

  searchbook(search:any,searchtext:any):void{
    console.log(searchtext,search);
    this.router.navigate(['search',search,searchtext]) 
}
}
