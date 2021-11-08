import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import {Router} from '@angular/router'

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private _dataService:DataService, private _router:Router) { }


  ngOnInit(): void {
  }
  onEdit(book : any){
    this._router.navigate(['/edit',book.Id]);
  }

  onView(book : any){
    this._router.navigate(['/view',book.Id]);
  }
adminlogout(){
  localStorage.removeItem('admintoken')
  window.location.reload();
}
  // onDelete(id:number){
  //   this._dataService.deleteBook(id).subscribe();
  //   alert("Are you sure?");
  //   this.ngOnInit();

  // }

}
