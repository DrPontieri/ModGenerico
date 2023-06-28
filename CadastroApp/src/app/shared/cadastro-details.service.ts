import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaderResponse, HttpResponse } from '@angular/common/http';
import { CadastroDetails } from './cadastro-details.model';
import { Form } from '@angular/forms';
import { Observable } from 'rxjs';
import { CadastroDetailsDp } from './cadastro-details-dp.model';

@Injectable({
  providedIn: 'root'
})
export class CadastroDetailsService {

  constructor(private http:HttpClient) { }

  readonly BaseUrl ='https://localhost:7095/api/PessoasAbstract';
  formData: CadastroDetails = new CadastroDetails();
  list: CadastroDetails[];

PostPessoa(){
    return this.http.post(this.BaseUrl, this.formData);
  }

GetPessoasList(){
  return this.http.get(this.BaseUrl).subscribe(data => {
    this.list = data as CadastroDetails[]
  })

}






}
