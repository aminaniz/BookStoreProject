import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-allorders',
  templateUrl: './allorders.component.html',
  styleUrls: ['./allorders.component.css']
})
export class AllordersComponent implements OnInit {
Customers:any;
Order:any;
  constructor(private _dataService:DataService) { }

  ngOnInit(): void {
    this._dataService.getCustomers().subscribe(data => this.Customers = data);
  }
onView(id:any):void{
  this._dataService.getOrder(id).subscribe((data: any) => this.Order = data);  
    console.log(this.Order);
}
}
