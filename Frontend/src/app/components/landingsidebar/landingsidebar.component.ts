import { Component, OnInit } from '@angular/core';
import {CategoryService }from 'src/app/services/category.service'
import {category} from 'src/app/category'
import { BooksService } from 'src/app/services/books.service';
import {Router} from '@angular/router'

@Component({
  selector: 'app-landingsidebar',
  templateUrl: './landingsidebar.component.html',
  styleUrls: ['./landingsidebar.component.css']
})
export class LandingsidebarComponent implements OnInit {
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
    // window.location.reload();
    this.router.navigate(['books',catId])
}

}
