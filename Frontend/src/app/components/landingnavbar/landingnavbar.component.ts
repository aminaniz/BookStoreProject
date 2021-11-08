import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-landingnavbar',
  templateUrl: './landingnavbar.component.html',
  styleUrls: ['./landingnavbar.component.css']
})
export class LandingnavbarComponent implements OnInit {
loggedIn:any;
  constructor(private auth : AuthService) { }

  ngOnInit(): void {
    if(this.auth.loggedIn()){
      this.loggedIn = true;
    }
    else{
      this.loggedIn=false;
    }
  }
  logout(){
    localStorage.removeItem('token'); 
  localStorage.removeItem('user'); 
    window.location.reload();
  }



}
