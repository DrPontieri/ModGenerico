import { Component, OnInit } from '@angular/core';
import { CadastroDetails } from 'src/app/shared/cadastro-details.model';
import { CadastroDetailsService } from 'src/app/shared/cadastro-details.service';


@Component({
  selector: 'app-cadastro-details-form',
  templateUrl: './cadastro-details-form.component.html',
  styles: [
  ]
})

export class CadastroDetailsFormComponent implements OnInit {
  isValidFormSubmitted = false;
  validateEmail = true;
  emailPattern = '^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$';
  CadastroDetails = new CadastroDetails();
  constructor(public service:CadastroDetailsService){

  }

  ngOnInit(): void {
  }
  onFormSubmit(form: CadastroDetails) {
    this.service.formData.email = this.emailPattern;
 }
}
