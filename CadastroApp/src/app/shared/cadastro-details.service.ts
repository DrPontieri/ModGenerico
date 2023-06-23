import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CadastroDetails } from './cadastro-details.model';

@Injectable({
  providedIn: 'root'
})
export class CadastroDetailsService {

  constructor(private http:HttpClient) { }

  readonly BaseUrl ='https://localhost:7095/api/PessoasAbstract';
  formData: CadastroDetails = new CadastroDetails();
}
