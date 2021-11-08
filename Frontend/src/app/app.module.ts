import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import * as $ from 'jquery';
import * as modal from 'bootstrap';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { FooterComponent } from './components/footer/footer.component';
import { CustomerComponent } from './components/admin/customer/customer.component';
import { NavbarComponent } from './components/admin/navbar/navbar.component';
import { DashboardComponent } from './components/admin/dashboard/dashboard.component';
import { SidebarComponent } from './components/admin/sidebar/sidebar.component';
import { LandingpageComponent } from './components/landingpage/landingpage.component';
import { LandingnavbarComponent } from './components/landingnavbar/landingnavbar.component';
import { LandingsidebarComponent } from './components/landingsidebar/landingsidebar.component';
import { LandingadComponent } from './components/landingad/landingad.component';
import { Landingcard1Component } from './components/landingcard1/landingcard1.component';
import { Landingcard2Component } from './components/landingcard2/landingcard2.component';
import { LandingheaderComponent } from './components/landingheader/landingheader.component';
import { CategoryComponent } from './components/admin/category/category.component';
import { BooksComponent } from './components/admin/books/books.component';
import { BooksbycatComponent } from './components/booksbycat/booksbycat.component';

import { CartComponent } from './components/checkout/cart/cart.component';
import { CartItemsComponent } from './components/checkout/cart-items/cart-items.component';
import {Ng2OrderModule} from 'ng2-order-pipe';
import {Ng2SearchPipeModule} from 'ng2-search-filter';
import {NgxPaginationModule} from 'ngx-pagination';



import { BookdetailsComponent } from './components/bookdetails/bookdetails.component';
import { BooksearchComponent } from './components/booksearch/booksearch.component';
import { Landingcard3Component } from './components/landingcard3/landingcard3.component';
import { AdminloginComponent } from './components/adminlogin/adminlogin.component';
import { Similarcard1Component } from './components/similarcard1/similarcard1.component';
import { CouponComponent } from './components/admin/coupon/coupon.component';
import { CatnavComponent } from './components/catnav/catnav.component';
import { AboutComponent } from './components/about/about.component';
import { GalleryComponent } from './components/gallery/gallery.component';
import { BlogComponent } from './components/blog/blog.component';
import { OrdersComponent } from './components/checkout/orders/orders.component';
import { SuccessComponent } from './components/success/success.component';
import { MyordersComponent } from './components/myorders/myorders.component';
import { AllordersComponent } from './components/admin/allorders/allorders.component';
import { AddressComponent } from './components/address/address.component';
import { WishlistComponent } from './components/wishlist/wishlist.component';
import { MyprofileComponent } from './components/myprofile/myprofile.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    FooterComponent,
    CustomerComponent,
    NavbarComponent,
    DashboardComponent,
    SidebarComponent,
    LandingpageComponent,
    LandingnavbarComponent,
    LandingsidebarComponent,
    LandingadComponent,
    Landingcard1Component,
    Landingcard2Component,
    LandingheaderComponent,
    CategoryComponent,
    BooksComponent,
    BooksbycatComponent,
    BookdetailsComponent,
    CartComponent,
    CartItemsComponent,
      BooksearchComponent,
      Landingcard3Component,
      AdminloginComponent,
      Similarcard1Component,
      CouponComponent,
      CatnavComponent,
      AboutComponent,
      GalleryComponent,
      BlogComponent,
    OrdersComponent,
    SuccessComponent,
    MyordersComponent,
    AllordersComponent,
    AddressComponent,
    WishlistComponent,
    MyprofileComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    Ng2SearchPipeModule,
    Ng2OrderModule,
    NgxPaginationModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
