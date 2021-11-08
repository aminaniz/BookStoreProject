import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';
import {Router} from '@angular/router'
@Component({
  selector: 'app-landingcard1',
  templateUrl: './landingcard1.component.html',
  styleUrls: ['./landingcard1.component.css']
})
export class Landingcard1Component implements OnInit {

  categories:any;
  res:any;
  cat1:any;
  cat2:any;
 
   constructor(private categoryservice:CategoryService,private router:Router) { }
 
   ngOnInit(): void {
     this.categoryservice.getCategories().subscribe(res=>{
       this.categories=res;
       this.cat1=res.slice(0,4);
       this.cat2=res.slice(4,8);
     })
   }

   findBooks(catId:any){
    this.router.navigate(['books',catId])
}

}
