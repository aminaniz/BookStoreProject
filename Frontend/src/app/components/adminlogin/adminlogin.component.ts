import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-adminlogin',
  templateUrl: './adminlogin.component.html',
  styleUrls: ['./adminlogin.component.css']
})
export class AdminloginComponent implements OnInit {

  public message= '';
  public alertClassName = 'alert-success';
  constructor(private _authService: AuthService, private _router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(data: any){
    console.log(data);
    this._authService.adminlogin(data).subscribe((response) => {
      console.log(response);
      localStorage.setItem('admintoken', response.Username);
      localStorage.setItem('type', 'admin');
      if (response.Username!=null){
        this._router.navigate(['admin'])
      }
      this.message = 'Login successfully';
      this.alertClassName = 'alert-success';
      
    }, (error) => {
      this.message ="Login Failed";
      this.alertClassName = 'alert-danger';
    })
  }
}
