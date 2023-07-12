import { Injectable, Type } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CadastroDetails } from './cadastro-details.model';
import { NgModel } from '@angular/forms';
import { Observable, Observer } from 'rxjs';

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

  DeletePessoa(id: number){
    this.http.delete(this.BaseUrl);
  }


  SubscriptionService(
    myserviceobservable: Observable<any>,
    myserviceobserver: object,
    listcompletefunctions: any){

    const myObserver={
      next:(Observer: Partial<Observer<typeof myserviceobserver>>) => console.log(Observer),
      error:(err:Error) => console.error('Observer got an error: ' + err),
      complete:(listcompletefunctions)}

  myserviceobservable.subscribe(myObserver)
   }

}

