import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  model : any = {}
  //loggedIn : boolean ; cambiamo metodo ed usiamo l'ogetto pipe

  //currentUser$ : Observable<User>;
  //Inseriamo il nostro servizio all'interno di questa componente nav usando il costruttore
  constructor(public accountService: AccountService) {}

  ngOnInit(): void {
    //this.getCurrentUser();
    //this.currentUser$ = this.accountService.currentUser$;
  }

  login () {
    this.accountService.login(this.model).subscribe(response => {
        console.log(response);
       // this.loggedIn = true;
    } , error => {
        console.log(error);
    })
  }

  logout(){
      this.accountService.logout();
   // this.loggedIn = false;
  }

 /* getCurrentUser(){

    this.accountService.currentUser$.subscribe(user => {
      this.loggedIn = !!user;// i doppi punti exclamativi trasformano il nostro oggetto in un billion
    } , error => {
      console.log(error);
    })
  } Non abbiamo piu bisogno do qiesto metodo ormai...*/

}
