import { Component, OnInit } from '@angular/core';
import {User} from 'src/app/user';
import {AuthService} from 'src/app/services/auth.service'
import {Router} from '@angular/router'
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public alertClassName = 'alert-success'
  public userModel = new User();
  public message = '';

  constructor(private _authService:AuthService, private _router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(){
    this._authService.register(this.userModel).subscribe((response) => {
      this.message = response;
      this.alertClassName = 'alert-success'
      this._router.navigate(['/home']);

    }, (error) => {
      this.alertClassName = 'alert-danger'
      this.message = "Registration failed"
    })
  }

}
