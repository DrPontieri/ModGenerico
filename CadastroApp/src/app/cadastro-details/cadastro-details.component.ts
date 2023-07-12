import { Component, OnInit } from '@angular/core';
import { CadastroDetailsService } from '../shared/cadastro-details.service';
import { CadastroDetails } from '../shared/cadastro-details.model';
import { concatAll } from 'rxjs/internal/operators/concatAll';
import { map } from 'rxjs/internal/operators/map';

@Component({
  selector: 'app-cadastro-details',
  templateUrl: './cadastro-details.component.html',
  styles: [

  ]
})
export class CadastroDetailsComponent implements OnInit {

  constructor(public service:CadastroDetailsService){}

  ngOnInit(): void {
    this.service.GetPessoasList()
  }



}
