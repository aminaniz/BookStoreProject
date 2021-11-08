import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-myorders',
  templateUrl: './myorders.component.html',
  styleUrls: ['./myorders.component.css']
})
export class MyordersComponent implements OnInit {
  User:any;
Order:any;
  constructor(private _dataService:DataService) { }

  ngOnInit(): void {
    this.User = localStorage.getItem('user');
    this.User = JSON.parse(this.User);
    this._dataService.getOrder(this.User.UserId).subscribe((data: any) => this.Order = data);  
    console.log(this.Order);
  }

}
