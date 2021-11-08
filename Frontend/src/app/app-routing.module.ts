import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BooksComponent } from './components/admin/books/books.component';
import { CategoryComponent } from './components/admin/category/category.component';
import { CustomerComponent } from './components/admin/customer/customer.component';

import { CartComponent } from './components/checkout/cart/cart.component';

import { DashboardComponent } from './components/admin/dashboard/dashboard.component';
import { BooksbycatComponent } from './components/booksbycat/booksbycat.component';

import { LandingpageComponent } from './components/landingpage/landingpage.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { BookdetailsComponent } from './components/bookdetails/bookdetails.component';
import { BooksearchComponent } from './components/booksearch/booksearch.component';
import { AdminloginComponent } from './components/adminlogin/adminlogin.component';
import { CouponComponent } from './components/admin/coupon/coupon.component';
import { AboutComponent } from './components/about/about.component';
import { GalleryComponent } from './components/gallery/gallery.component';
import { BlogComponent } from './components/blog/blog.component';
import { OrdersComponent } from './components/checkout/orders/orders.component';
import { AuthGuard } from './guard/auth.guard';
import { SuccessComponent } from './components/success/success.component';
import { AllordersComponent } from './components/admin/allorders/allorders.component';
import { MyordersComponent } from './components/myorders/myorders.component';
import { AdminGuard } from './guard/admin.guard';
import { WishlistComponent } from './components/wishlist/wishlist.component';
import { MyprofileComponent } from './components/myprofile/myprofile.component';

const routes: Routes = [
  {path:'login', component:LoginComponent},
  {path:'register', component:RegisterComponent},
  {path:'admin/customer', component:CustomerComponent,canActivate :[AdminGuard]},
  {path:'home', component:LandingpageComponent},
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {path:'admin/category', component:CategoryComponent,canActivate :[AdminGuard]},
  {path:'admin/coupon', component:CouponComponent,canActivate :[AdminGuard]},
  {path:'cart', component:CartComponent,canActivate :[AuthGuard]},
  {path:'orders', component:OrdersComponent,canActivate :[AuthGuard]},
  {path:'admin/books', component:BooksComponent,canActivate :[AdminGuard]},
  {path:'about', component:AboutComponent},
  {path:'books/:id',component:BooksbycatComponent},
  {path:'admin',component:DashboardComponent,canActivate :[AdminGuard]},
  {path:'details/:name',component:BookdetailsComponent},
  {path:'search/:type/:name',component:BooksearchComponent},
  {path:'adminlogin',component:AdminloginComponent},
  {path:'gallery',component:GalleryComponent},
  {path:'blog',component:BlogComponent},
  {path:'success',component:SuccessComponent},
  {path:'admin/allorders',component:AllordersComponent,canActivate :[AdminGuard]},
  {path:'myorders',component:MyordersComponent,canActivate :[AuthGuard]},
  {path:'wishlist', component:WishlistComponent,canActivate:[AuthGuard]},
  {path:'myprofile', component:MyprofileComponent,canActivate:[AuthGuard]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
