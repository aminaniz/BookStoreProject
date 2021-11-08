import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BooksService } from 'src/app/services/books.service';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-catnav',
  templateUrl: './catnav.component.html',
  styleUrls: ['./catnav.component.css']
})
export class CatnavComponent implements OnInit {

  categories:any;
  res:any;
  books:any;
 
   constructor(private categoryservice:CategoryService,private bookservice : BooksService ,private router:Router) { }
 
   ngOnInit(): void {
     this.categoryservice.getCategories().subscribe(res=>{
       this.categories=res;
     })
   }
 
   
   findBooks(catId:any){
     this.router.navigate(['books',catId])
 }
}
