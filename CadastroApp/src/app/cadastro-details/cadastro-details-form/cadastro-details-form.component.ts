import { Component, OnInit } from '@angular/core';
import { Form, NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CompleteNotification, Observable, Observer } from 'rxjs';
import { CadastroDetails } from 'src/app/shared/cadastro-details.model';
import { CadastroDetailsService } from 'src/app/shared/cadastro-details.service';





@Component({
  selector: 'app-cadastro-details-form',
  templateUrl: './cadastro-details-form.component.html',
  styles: [
  ]
})

export class CadastroDetailsFormComponent implements OnInit {

constructor(public service:CadastroDetailsService,
  private toastr:ToastrService){

}

ngOnInit(): void {

}

onSubmit(form:NgForm){
  const myobservable = this.service.PostPessoa();
  const listcompletefunctionsok = () =>{ this.resetForm(form)};

  this.service.SubscriptionService(
    myobservable,
    CadastroDetails,
    listcompletefunctionsok)
//   const myobservable =


//   const myObserver={
//     next:(Observer: Partial<Observer<CadastroDetails>>) => console.log(Observer),
//     error:(err:Error) => console.error('Observer got an error: ' + err),
//     complete:(() => { this.resetForm(form); this.toastr.success('Enviado com Sucesso!!', 'Cadastro Pessoa')})}

// myobservable.subscribe(myObserver)
}

 resetForm(form:NgForm){
  form.form.reset();
  this.service.formData = new CadastroDetails();
  this.toastr.success('Enviado com Sucesso!!', 'Cadastro Pessoa'),
  this.service.GetPessoasList()
}

}



