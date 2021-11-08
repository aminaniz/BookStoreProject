import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public message= '';
  public alertClassName = 'alert-success';
  constructor(private _authService: AuthService, private _router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(data: any){
    this._authService.login(data).subscribe((response) => {
      console.log(response);
      localStorage.setItem('token', response.Email);
      localStorage.setItem('user', JSON.stringify(response));
      this.message = 'Login successfully';
      this.alertClassName = 'alert-success';
      this._router.navigate(['/home']);
    }, (error) => {
      this.message ="Login Failed";
      this.alertClassName = 'alert-danger';
    })
  }

}
