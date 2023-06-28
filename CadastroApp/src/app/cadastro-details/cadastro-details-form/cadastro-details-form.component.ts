import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CompleteNotification, Observable } from 'rxjs';
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

  const myObserver={
    error:(err:Error) => console.error('Observer got an error: ' + err),
    complete: (res:CompleteNotification) => console.log('Observer got a complete notification'),
  };

myobservable.subscribe(res =>{
  this.resetForm(form);
  this.toastr.success('Enviado com Sucesso!!', 'Cadastro Pessoa')
})
};

resetForm(form:NgForm){
  form.form.reset();
  this.service.formData = new CadastroDetails();
}

}
