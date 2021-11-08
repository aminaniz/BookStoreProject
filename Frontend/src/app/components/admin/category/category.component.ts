import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';
import {category} from 'src/app/category'
@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  categories:any;
update:any;
delete:any;
msgstatus=false;
public categoryModel = new category();
  msg:any;
  constructor(private categoryservice:CategoryService) { }

  ngOnInit(): void {
   this.categoryservice.getCategories().subscribe(res=>{
     this.categories=res;
     this.update=res[0];
     this.delete=res[0];
   })
  }
  onUpdate(category:any):void{
    this.update=category;
  }
  onDelete(id:any):void{
    this.delete=id;
    
  }

  closewarning():void{
    this.msgstatus=false;
    window.location.reload();
  }

  addcategory():void{
    this.categoryservice.addCategory(this.categoryModel).subscribe(res=>{
      this.msg=res;
      this.msgstatus=true;
      console.log(res);
   
    })

  }
  updatecategory():void{
    this.categoryservice.updateCategory(this.update).subscribe(res=>{
      this.msg=res;
      
      this.msgstatus=true;
      console.log(res);
     
    })

  }

  deletecategory(id:any):void{
    this.categoryservice.deleteCategory(id).subscribe(res=>{
      this.msg=res;
      this.msgstatus=true;
      console.log(this.msg);
   
    })
  }

}
