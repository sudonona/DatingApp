import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = "https://localhost:5001/api/"
  //Creare un oservable per salvare/memorizare/store i nostri utenti
  //lo chiameremo un proprieta privata
  //ReplaySubject (soggetto di riproduzione) e un pò come un buiffer dove possiamo memorizzare i valori
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor( private http: HttpClient) { }

    //creiamo il metodo login 
    login(model: User){ // qui riceviamo un userDto o qualcosa che ci manderà l'API : ne facciamo qualcosa
        return this.http.post(this.baseUrl + 'account/login' , model).pipe(
            //vogliamo mappare usando la funzione map dal nostro XTS
            map((response : any) => {
                const user = response;

                if(user){
                  localStorage.setItem("user" , JSON.stringify(user)); //Aggiungere tutti gli utenti alla memoria locale
                  this.currentUserSource.next(user); //set/impostare il mnostro utente all'osservabile per sostituire l'oggetto
                }
            })
        )
    }

    register(model: any){
      return this.http.post(this.baseUrl + 'account/register' , model).pipe(
        map((user: User) => { //Questo mi permette di precisare che user e di tipo User (TypeScript) oppre user : any per evitare tutti tipi di problemi ..il bello di ANGULAR
            if (user){
              localStorage.setItem('user' , JSON.stringify(user));
              this.currentUserSource.next(user);
            }

            return user;
        })
      )
    }

    setCurrentUser(user: User){
      this.currentUserSource.next(user);
    }

    logout (){
      localStorage.removeItem('user');
      this.currentUserSource.next(null);
    }
}
