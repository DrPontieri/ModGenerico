export class CadastroDetails {
  //Pessoa
  id:number = 0;
  pessoaid:number=0;
  DtCadastro:string = '';

        //Dados Pessoais
        nome:string ='';
        email:string ='';
        pais:string ='';
        dtNascimento:string = '';

        //Logradouro
        cidade:string ='';
        estado:string ='';
        cep:string ='';
        endereco:string ='';
        numero:number;
        bairro:string ='';
        complemento:string ='';

        //PaymentDetail Detail
        cardownername:string ='';
        cardnumber:string ='';
        expirationdate:string ='';
        securitycode:string ='';
}
