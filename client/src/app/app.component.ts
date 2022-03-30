
import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'The Dating Application';
  //users: any;

  constructor(private accountService: AccountService) /*abbiamo tolto private http: HttpClient ,*/
  {
    /*Cancelliamo tutto cio che non ci serve piu(getUser) perché li spostiamo tutti all'interno della nostra componente home*/
  }

  ngOnInit() { //Inizializziamo il nostro componet navbar
      //this.getUser();
      //chiamo anche qui il metedo setCurrentUser
      this.setCurrentUser();
  }

  //Vogliamo rendere persistente il nostro login
  //Guardando nel browser per vedere se al suo interno, nella memoria locale per vedere se c'è una chiave o un oggetto con la chiave del'utente

  setCurrentUser(){
      const user : User = JSON.parse(localStorage.getItem('user'));
      this.accountService.setCurrentUser(user);
  }

  /*getUser (){
    this.http.get('https://localhost:5001/api/users').subscribe(response => {
        this.users = response;
        } , error => {console.log(error);
                    }   
      );
  }*/
  
}
