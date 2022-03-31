import { Component, OnInit , Output, EventEmitter } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

 //Questa proprietà di input ci permette di communicare tra il componente padre home et quello figlio register
  //@Input() usersFromHomeComponent: any;
  //Quello che vogliamo fare qui e quando clicchiamo sul pulsante cancel, emmettiamo un valore utilizzaondo appunto
  // questo evento Emitter che è una classe perciò le parentesi tonde sono necessarie
  @Output() cancelRegister = new EventEmitter();

  model :any = {};

  constructor(private accountService : AccountService , private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  register(){
    //console.log(this.model);
    this.accountService.register(this.model).subscribe(response => {
      console.log(response);
      this.cancel();
    } , error => {
          console.log(error);
          this.toastr.error(error.error); //mi mostra una finestra di popup con un messaggio di errore
    })
    
  }

  cancel(){
    //console.log('Cancelled'); emettere = mandare fuori, dare un risultato di una funzioneo altro
    //Qui vogliamo che qua quando si clicca su cancel, il nostro button emmetta falso 
    //ossia disattiva la modalità di registrazione nel componente home
    this.cancelRegister.emit(false);
  }

}
