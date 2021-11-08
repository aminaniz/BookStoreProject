import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import {Router} from '@angular/router';
import { CartItem } from 'src/app/CartItem';
import {Address} from 'src/app/Address'

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']
})
export class AddressComponent implements OnInit {

  User:any;
  constructor(private _dataService:DataService, private _router:Router ) { }
  Addresses:any;
  AddressModel=new Address();
  NewAddress=new Address();

  ngOnInit(): void {
    this.User = localStorage.getItem('user');
    this.User = JSON.parse(this.User);
    this._dataService.getAdresses(this.User.UserId).subscribe((data: any) => this.Addresses = data);

    // this.AddressModel.UserId=this.Addresses.;
    // console.log(this.Addresses);
    // this.Addresses = JSON.parse(this.Addresses);
    // for (let Address of this.Addresses) {
    //   this.lastAddress = Address;
    // }
  }
onChange(address:any){
  this.AddressModel=address;
}
  onSubmit(){
    console.log(this.AddressModel);
    this.AddressModel.UserId=this.User.UserId;
    this._dataService.updateAddess(this.User.UserId,this.AddressModel).subscribe();
    
  }
  onAdd(){
    console.log(this.NewAddress);
    this.NewAddress.UserId=this.User.UserId;
    this._dataService.addAddress(this.NewAddress).subscribe();
  }
  

}