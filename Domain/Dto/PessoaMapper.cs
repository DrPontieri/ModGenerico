using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class PessoaMapper
    {

        public PostPessoaDto toDto(Pessoa entity)
        {
            var dto = new PostPessoaDto
            {
                Id = entity.Id,
                pessoaid = entity.Id,
                DtCadastro = entity.DataCadastro.ToString(),
                nome = entity.DadosPessoais.Nome,
                email = entity.DadosPessoais.Email,
                pais = entity.DadosPessoais.Pais,
                dtNascimento = entity.DadosPessoais.DtNascimento.ToShortDateString(),
                
                cidade = entity.Logradouro.Cidade,
                estado = entity.Logradouro.Estado,
                bairro = entity.Logradouro.Bairro,
                cep = entity.Logradouro.Cep,
                complemento = entity.Logradouro.Complemento,
                numero = entity.Logradouro.Numero,
                endereco = entity.Logradouro.Endereco,
                
                cardownername = entity.PaymentDetail.CardOwnerName,
                cardnumber = entity.PaymentDetail.CardNumber,
                expirationdate = entity.PaymentDetail.ExpirationDate,
                securitycode = entity.PaymentDetail.SecurityCode,


            };
            
            return dto;
        }


        public Pessoa toEntity(PostPessoaDto dto)
        {
            Pessoa entity = new Pessoa 
            {
                Id = dto.Id,
                DataCadastro = Convert.ToDateTime(DateTime.Now),
                DadosPessoais = new DadosPessoais
                {
                    Nome = dto.nome,
                    Email = dto.email,
                    Pais =  dto.pais,
                    DtNascimento = Convert.ToDateTime(Convert.ToDateTime(dto.dtNascimento).ToShortDateString()),
                    PessoaId = dto.Id
                },
                Logradouro = new Logradouro
                {
                    Cidade = dto.cidade,
                    Estado = dto.estado,
                    Bairro = dto.bairro,
                    Cep = dto.cep,
                    Complemento = dto.complemento,
                    Numero = dto.numero,
                    Endereco = dto.endereco,
                    PessoaId = dto.Id
                    
                },
                PaymentDetail = new PaymentDetail
                {
                    CardOwnerName = dto.cardownername,
                    CardNumber = dto.cardnumber,
                    ExpirationDate = dto.expirationdate,
                    SecurityCode = dto.securitycode,
                    PessoaId = dto.Id
                }
            };

            return entity;
        }
    }
}
