import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import {Router} from '@angular/router';
@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  public Customers : any;
  Name:any;
  statusMsg:any;

  constructor(private _dataService:DataService, private _router:Router) { }

  ngOnInit(): void {
    this._dataService.getCustomers().subscribe(data => this.Customers = data);
    
  }
  Search(){
    if(this.Name == ""){
      this.ngOnInit();
    }else{
      this.Customers = this.Customers.filter((res: { Name: string; }) => {
        return res.Name.toLocaleLowerCase().match(this.Name.toLocaleLowerCase());

      })
    }
  }

  changeStatus(id:any,status:any):void{
    this._dataService.changeStatus(id,status).subscribe();
    window.location.reload();
   
    

  }
}
