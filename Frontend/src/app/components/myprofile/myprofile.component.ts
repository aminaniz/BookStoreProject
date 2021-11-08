import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-myprofile',
  templateUrl: './myprofile.component.html',
  styleUrls: ['./myprofile.component.css']
})
export class MyprofileComponent implements OnInit {
User:any;
  constructor() { }

  ngOnInit(): void {
    this.User = localStorage.getItem('user');
    this.User = JSON.parse(this.User);
  }

}
