import { Component, OnInit } from '@angular/core';
import{coupon} from 'src/app/coupon'
import { CouponService } from 'src/app/services/coupon.service';
@Component({
  selector: 'app-coupon',
  templateUrl: './coupon.component.html',
  styleUrls: ['./coupon.component.css']
})
export class CouponComponent implements OnInit {
msgstatus=false;
msg:any;
newcoupon=new coupon();
coupons:any;
update:any;
delete:any;
  constructor(private couponservice:CouponService) { }

  ngOnInit(): void {
    this.couponservice.getCoupons().subscribe(res=>{
      this.coupons=res;
      this.update=res[0];
      this.delete=res[0];
    })
  }
  closewarning():void{
    this.msgstatus=false;
    window.location.reload();
  }
  onUpdate(coupon:any){
    this.update=coupon;
  }
  updateCoupon():void{
    this.couponservice.updateCoupon(this.update).subscribe(res=>{
      this.msg=res;
      console.log(this.msg);
      this.msgstatus=true;
    })
  }
  addCoupon():void{
    this.couponservice.addCoupon(this.newcoupon).subscribe(res=>{
      this.msg=res;
      console.log(this.msg);
      this.msgstatus=true;
    })
  }
  changeStatus(id:any,status:any):void{
    this.couponservice.changeStatus(id,status).subscribe(res=>{
      window.location.reload();
      this.msg=res;
    })
  }
}
