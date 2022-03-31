import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common'; //ogni modulo Angular a bisogno di un CommonModule qdi viene importato automaticamente
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(), //per poetr usare la libreria dropdown ci serve il modulo
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],

  exports:[ //NELLA export non abbiamo bisogno di aggiungere le configurazioni forRoot()
    BsDropdownModule,
    ToastrModule
  ]
})
export class SharedModule { }
