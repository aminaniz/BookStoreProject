import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import {Router} from '@angular/router';
import { book } from 'src/app/book';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BooksService } from 'src/app/services/books.service';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})



export class BooksComponent implements OnInit {

  booklist: book[] = [];
  Books: any;
  Title:any;
  delete:any;
  update:any;
  msg:any;
  // Author:any;
  p:number =1;
  msgstatus=false;
  categories:any;
  public add=new book();

  constructor(private _dataService:DataService, private bookservice:BooksService,private categoryservice:CategoryService,
    private _router:Router, private _http:HttpClient) { }

  ngOnInit(): void {
    this._dataService.getBooks().subscribe(data => {
      this.Books = data;
    this.update=data[0]})
    this.categoryservice.getCategories().subscribe(res=>{
      this.categories=res;
    })
    
    console.log(this.Books);

    // console.log(this.Books);
  }

  onAdd():void{
    console.log(this.add);
    this.bookservice.addBook(this.add).subscribe(data=>{
      this.msg=data;
      this.msgstatus=true;
    })
  }

  Search(){
    if(this.Title == ""){
      this.ngOnInit();
    }else{
      this.Books = this.Books.filter((res: { Title: string; }) => {
        return res.Title.toLocaleLowerCase().match(this.Title.toLocaleLowerCase());

      })
    }
  }

  onUpdate(book:any):void{
    this.update=book;
  }
closewarning():void{
  this.msgstatus=false;
  window.location.reload();
}

  updateBook():void{
    this.bookservice.updateBook(this.update).subscribe(res=>{
      this.msg=res;
      this.msgstatus=true;
      console.log(res);
      
    })

  }


  key: string = 'BookId';
  reverse: boolean = false;
  sort(key: string){
    this.key= key;
    this.reverse = !this.reverse;
  }

}
