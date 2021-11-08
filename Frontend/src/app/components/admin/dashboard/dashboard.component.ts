import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
categories:any;
  constructor(private categoryservice:CategoryService) { }

  ngOnInit(): void {
    this.categoryservice.getCategories().subscribe(res=>{
      this.categories=res;
    })
  }

}
