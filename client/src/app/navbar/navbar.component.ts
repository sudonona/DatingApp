import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Toast, ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  model : any = {}
  
  constructor(public accountService: AccountService, private router: Router , private toastr : ToastrService) {}

  ngOnInit(): void {

  }

  login () {
    this.accountService.login(this.model).subscribe(response => {
       this.router.navigateByUrl('/members');
    } , error => {
        console.log(error);
        this.toastr.error(error.error);
    })
  }

  logout(){
      this.accountService.logout();
      this.router.navigateByUrl('/');
  }
}
